charp
[ClassInitialize]
public static void InitializeClass(TestContext testContext)
{
    var options = new ChromeOptions();
    options.AddArguments("--incognito");
    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
}
[TestMethod]
public void Login()
{
    driver.Navigate().GoToUrl("https://localhost:44399/");
    driver.FindElement(By.Id("i0116")).Clear();
    driver.FindElement(By.Id("i0116")).SendKeys("test@test.onmicrosoft.com");
    driver.FindElement(By.Id("i0116")).SendKeys(Keys.Enter);
    driver.FindElement(By.Id("i0118")).Clear();
    driver.FindElement(By.Id("i0118")).SendKeys("password");
    Thread.Sleep(500);
    driver.FindElement(By.Id("i0118")).SendKeys(Keys.Enter);
    driver.FindElement(By.Id("idSIButton9")).Click();
}
