	foreach (String line in File.ReadLines(@"input.txt").Skip(lineint))
	{
		string[] data = line.Split(':');
		string query = data[0];
		string uri = data[1];
		if (driver.FindElements(By.Name("search")).Count != 0)
		{
			// exists
			driver.FindElement(By.Name("search")).SendKeys(search);
			driver.FindElement(By.Name("uri")).SendKeys(uri + Keys.Enter);
			if (driver.FindElements(By.XPath("//*[@id='modal']/div/div/div/p[contains(text(), 'Search not found')]")).Count == 0)
			{
			     Console.WriteLine("Success");
			     break; // exit the loop
			}
		}
		else
		{
			driver.Manage().Cookies.DeleteAllCookies();
			driver.Navigate().Refresh();
		}
	}
