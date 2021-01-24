    using System.Linq;
    using System.Collections.Generic;
    
    List<IWebElement> options = driver.FindElements(By.TagName("tr")).ToList();
    IWebElement selectOption = options.Find(x => x.FindElement(By.TagName("td")).Text.Contains("Biodiversiteti"));
    selectOption.Click();
