    public void ClickEdit(string locationName)
    {
        driver.FindElements(By.TagName("tr"))
            .Where(row => row.FindElements(By.TagName("td"))[1] == locationName).Single()
            .FindElement(By.TagName("a")).Click();
    }
