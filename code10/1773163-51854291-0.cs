    IList<IWebElement> attachmentList = driver.FindElements(By.ClassName("comment-box"));
    
    foreach (IWebElement element in attachmentList)
    {
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine(element.Text);
    }
