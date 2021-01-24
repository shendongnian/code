using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace ResearchDevelopment
{
    internal class Program
    {  
        static void Main(string[] args)
        {
            var driver = new ChromeDriver() { Url = "http://www.google.co.za" };
            var searchInput = driver.FindElement(By.XPath("//input[@aria-label='Search']"));
            PopulateElementJs(driver, searchInput, "");
            searchInput.SendKeys(Keys.Enter); // Optional
            driver?.Quit();
        }
        public static void PopulateElementJs(IWebDriver driver, IWebElement element, string text)
        {
            var script = "arguments[0].value=' " + text + " ';";
            ((IJavaScriptExecutor)driver).ExecuteScript(script, element);
        }
    }
}
packages.config
<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Selenium.Chrome.WebDriver" version="76.0.0" targetFramework="net472" />
  <package id="Selenium.Support" version="3.0.0" targetFramework="net472" />
  <package id="Selenium.WebDriver" version="3.0.0" targetFramework="net472" />
</packages>
