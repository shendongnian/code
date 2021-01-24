    IList<IWebElement> List = driver.FindElements(By.Id("contactList"));
    List<String> NewList = new List<String>();
    foreach (var item in List)
            {
                NewList.Add(item.Text);
            }
    Actions action1 = new Actions(driver);
    action1.MoveToElement(NewList[<Index number>]).Perform();
    action1.Click(NewList[<Index number>]).Perform();
