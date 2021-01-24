    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Interactions;
    var driver = new WebDriver();
    var elements = driver.GetElementsByClassName("ui-state-default ui-selectee");
    var action = new Actions(driver);
    action.KeyDown(Keys.Control);
    foreach (var element in elements)
    {
        // If element properties match your selection
        element.Click()
    }
