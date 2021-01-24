    public void ClickEdit(string locationName)
    {
        driver.FindElements(By.TagName("tr"))
            .Where(row => row.FindElements(By.TagName("td"))[1] == locationName)
            .FindElement(By.TagName("a")).Click();
    }
