    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Interactions.Internal;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.IE;
    using NUnit.Framework;
    using System.Text.RegularExpressions;
    namespace sae_test
    {   class Program
        {   private static string baseURL;
            private static StringBuilder verificationErrors;
        static void Main(string[] args)
        {   // test with firefox
            IWebDriver driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
            // test with IE
            //InternetExplorerOptions options = new InternetExplorerOptions();
            //options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            //IWebDriver driver = new OpenQA.Selenium.IE.InternetExplorerDriver(options);
            SetupTest();
            driver.Navigate().GoToUrl(baseURL + "Account/Login.aspx");
            IWebElement inputTextUser = driver.FindElement(By.Id("MainContent_LoginUser_UserName"));
            inputTextUser.Clear();
            driver.FindElement(By.Id("MainContent_LoginUser_UserName")).Clear();
            driver.FindElement(By.Id("MainContent_LoginUser_UserName")).SendKeys("usuario");
            driver.FindElement(By.Id("MainContent_LoginUser_Password")).Clear();
            driver.FindElement(By.Id("MainContent_LoginUser_Password")).SendKeys("123");
            driver.FindElement(By.Id("MainContent_LoginUser_LoginButton")).Click();
            driver.Navigate().GoToUrl(baseURL + "finanzas/consulta.aspx");
            // view combo element
            IWebElement comboBoxSistema = driver.FindElement(By.Id("MainContent_rcbSistema_Arrow"));
            //Then click when menu option is visible 
            comboBoxSistema.Click();
            System.Threading.Thread.Sleep(500);
            // container of elements systems combo
            IWebElement listaDesplegableComboSistemas = driver.FindElement(By.Id("MainContent_rcbSistema_DropDown"));
            listaDesplegableComboSistemas.FindElement(By.XPath("//li[text()='BOMBEO MECANICO']")).Click();
            System.Threading.Thread.Sleep(500);
            IWebElement comboBoxEquipo = driver.FindElement(By.Id("MainContent_rcbEquipo_Arrow"));
            //Then click when menu option is visible 
            comboBoxEquipo.Click();
            System.Threading.Thread.Sleep(500);
            // container of elements equipment combo
            IWebElement listaDesplegableComboEquipos = driver.FindElement(By.Id("MainContent_rcbEquipo_DropDown"));
            listaDesplegableComboEquipos.FindElement(By.XPath("//li[text()='MINI-V']")).Click();
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("MainContent_Button1")).Click();            
            try
            {   Assert.AreEqual("BOMBEO MECANICO_22", driver.FindElement(By.XPath("//*[@id=\"MainContent_RejillaRegistroFinanciero_ctl00_ctl04_LabelSistema\"]")).Text);
            }
            catch (AssertionException e)
            {   verificationErrors.Append(e.Message);
            }
            // verify coin format $1,234,567.89 usd
            try
            {   Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//*[@id=\"MainContent_RejillaRegistroFinanciero_ctl00_ctl04_labelInversionInicial\"]")).Text, "\\$((,)*[0-9]*[0-9]*[0-9]+)+(\\.[0-9]{2})? usd"));
            }
            catch (AssertionException e)
            {   verificationErrors.Append(e.Message);
            }
            try
            {   Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//*[@id=\"MainContent_RejillaRegistroFinanciero_ctl00_ctl04_labelCostoOpMantto\"]")).Text, "\\$((,)*[0-9]*[0-9]*[0-9]+)+(\\.[0-9]{2})? usd"));
            }
            catch (AssertionException e)
            {   verificationErrors.Append(e.Message);
            }
            try
            {   Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//*[@id=\"MainContent_RejillaRegistroFinanciero_ctl00_ctl04_labelCostoEnergia\"]")).Text, "\\$((,)*[0-9]*[0-9]*[0-9]+)+(\\.[0-9]{2})? usd"));
            }
            catch (AssertionException e)
            {   verificationErrors.Append(e.Message);
            }
            try
            {   Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//*[@id=\"MainContent_RejillaRegistroFinanciero_ctl00_ctl04_labelcostoUnitarioEnergia\"]")).Text, "\\$((,)*[0-9]*[0-9]*[0-9]+)+(\\.[0-9]{2})? usd"));
            }
            catch (AssertionException e)
            {   verificationErrors.Append(e.Message);
            }
            // verify number format 1,234,567.89
            try
            {   Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//*[@id=\"MainContent_RejillaRegistroFinanciero_ctl00_ctl04_labelConsumo\"]")).Text, "((,)*[0-9]*[0-9]*[0-9]+)+(\\.[0-9]{2})?"));
            }
            catch (AssertionException e)
            {   verificationErrors.Append(e.Message);
            }
            System.Console.WriteLine("errores: " + verificationErrors);
            System.Threading.Thread.Sleep(20000);
            driver.Quit();
        }
        public static void SetupTest()
        {   baseURL = "http://127.0.0.1:8081/ver.rel.1.2/";
            verificationErrors = new StringBuilder();
        }
        protected static void mouseOver(IWebDriver driver, IWebElement element)
        {   Actions builder = new Actions(driver);
            builder.MoveToElement(element);
            builder.Perform();
        }
        public static void highlightElement(IWebDriver driver, IWebElement element)
        {   for (int i = 0; i < 2; i++)
            {   IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",
                        element, "color: yellow; border: 2px solid yellow;");
                js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",
                        element, "");
            }
        }
    }
    }
