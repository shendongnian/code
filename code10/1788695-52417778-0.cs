	public void locateElement(int i) {
		driver.findElement(By.xpath("(//a[@class=''])[" + i + "]")).click();
	}
		try {
			List<WebElement> rows = new List<WebElement>(table.FindElements(By.TagName("tr")));
			for (int i = 1; i <= rows.size(); i++) {
                //To locate on main page, need to use i for each row
				locateElement(i);   
				rows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
