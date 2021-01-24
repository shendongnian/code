	namespace Example
	{
		using Microsoft.VisualStudio.TestTools.UnitTesting;
		using OpenQA.Selenium;
		using OpenQA.Selenium.Chrome;
		using OpenQA.Selenium.Remote;
		public class ChromeDriverWithTouchScreen : ChromeDriver, IHasTouchScreen
		{
			public ITouchScreen TouchScreen => new RemoteTouchScreen(this);
			public ChromeDriverWithTouchScreen(ChromeOptions options) : base(options)
			{
			}
		}
		[TestClass]
		public class ExampleTest
		{
			IWebDriver chromeDriver;
			[TestInitialize]
			public void Init()
			{
				var chromeOptions = new ChromeOptions();
				chromeOptions.EnableMobileEmulation("Nexus 6P"); // Allows the Chrome browser to emulate a mobile device.
				chromeDriver = new ChromeDriverWithTouchScreen(chromeOptions);
			}
			[TestMethod]
			public void ExampleTestMethod()
			{
				chromeDriver.Navigate().GoToUrl("https://example.com");
				IWebElement link = chromeDriver.FindElement(By.CssSelector("a"));
				// Threw exception:
				// The IWebDriver object must implement or wrap a driver that implements IHasTouchScreen.
				var touchActions = new OpenQA.Selenium.Interactions.TouchActions(chromeDriver);
				touchActions
					.SingleTap(link)
					.Build()
					.Perform();
			}
			[TestCleanup]
			public void Cleanup()
			{
				chromeDriver.Quit();
			}
		}
	}
