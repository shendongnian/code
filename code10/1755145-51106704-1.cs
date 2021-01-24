     public class DatePickerSelection
    	{
    		public const string cellSelector = ".md2-calendar-body-cell > .md2-calendar-body-cell-content";
    
    		public static void SetCalenderDate(IWebDriver driver, string EnteredDate)
    		{
    			string[] dateEntered = EnteredDate.Split("/".ToCharArray()); //to split the dates into day, month and year value
    			int month = int.Parse(dateEntered[0]);
    			string mon = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month);
    			int day = int.Parse(dateEntered[1]);
    			int year = int.Parse(dateEntered[2]);
    
    			int NoOfClicks = DateTime.Now.Year - year; //to select the year
    			driver.FindElement(By.CssSelector("div.md2-calendar-header-year")).Click();
    			for (int i = 0; i < NoOfClicks; i++)
    			{
    				driver.FindElement(By.CssSelector("div.md2-calendar-next-button")).Click();
    			}
    			IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
    			js.ExecuteScript("document.body.style.zoom='100%'");
    			SetMonthAndDate(driver, mon, day);
    		}
    		public static void SetMonthAndDate(IWebDriver driver, string month, int day)
    		{
    			SelectMonth(driver, month);
    			SelectDay(driver, day.ToString());
    		}
    
    		public static void SelectMonth(IWebDriver driver, string mon)
    		{
    			IList<IWebElement> webElements = driver.FindElements(By.CssSelector(cellSelector));
    			IWebElement text = webElements.FirstOrDefault(x => x.Text.ToLower().Equals(mon.ToLower()));
    			text.Click();
    			Thread.Sleep(Timing.TimeOut);
    		}
    
    		public static void SelectDay(IWebDriver driver, string day)
    		{
    			IList<IWebElement> webElements = driver.FindElements(By.CssSelector(cellSelector));
    			IWebElement text = webElements.FirstOrDefault(x => x.Text.Contains(day));
    			text.Click();
    			Thread.Sleep(Timing.TimeOut);
    		}
    	}
	
