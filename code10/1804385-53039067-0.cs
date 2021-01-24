    IList<IWebElement> WeekDays = Chromedriver.FindElements(By.XPath("//td[@class='dxeCalendarDay']"));
    
    foreach (IWebElement Days in WeekDays)
    {
        string WeekDaysResults = Days.Text;
    
        if(string.IsNullOrEmpty(WeekDaysResults))
        {
            //Do Nothing
        }
        else
        {
            if(WeekDaysResults == FirstDayOfCurrentMonth)
            {
                Days.Click();
                Debug.WriteLine("Week Days: " + WeekDaysResults);
            }        
        } 
        WeekDays = Chromedriver.FindElements(By.XPath("//td[@class='dxeCalendarDay']"));
    }
