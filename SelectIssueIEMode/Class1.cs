using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SelectIssueIEMode
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestSelect() {
            Console.WriteLine("Starting driver");
            var driver = GetDriver();
            var url = "file:///" + AppDomain.CurrentDomain.BaseDirectory + "login.html";
            Console.WriteLine("Url to use is : " + url);
            driver.Url = url;
            var element = driver.FindElement(By.TagName("select"));
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue("BRA");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            selectElement.SelectByValue("CZE");
        }

        public static IWebDriver GetDriver() {

            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var driverServerExe = "IEDriverServer.exe";
            var ieService = InternetExplorerDriverService.CreateDefaultService(dir, driverServerExe);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            var ieOptions = new InternetExplorerOptions
            {
                    EnableNativeEvents = true,
                    //  EnsureCleanSession = true,
                    IgnoreZoomLevel = true,
                    RequireWindowFocus = false,
                    IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    AttachToEdgeChrome = true,
                    EnablePersistentHover = true,
                    EdgeExecutablePath = "C:\\Progra~2\\Microsoft\\Edge\\Application\\msedge.exe"
            };

            var driver = new InternetExplorerDriver(ieService,ieOptions,TimeSpan.FromSeconds(30));
            Thread.Sleep(TimeSpan.FromSeconds(5));
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }

}
