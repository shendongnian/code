    public IWebElement WaitForElementToBeOnscreen(By locator)
    {
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        wait.Until<IWebElement>(d =>
        {
            IWebElement element = d.FindElement(locator);
            if (element.Location.X > 0 &&
                element.Location.X < Driver.Manage().Window.Size.Width &&
                element.Location.Y > 0 &&
                element.Location.Y < Driver.Manage().Window.Size.Height)
            {
                return element;
            }
            return null;
        });
        return null;
    }
