	public void FindIconState() 
    {
		String IconClasses = driver.findElement(By.xpath("//span[contains(@class,'x-towbook-lock')]")).GetAttribute("class");
		if (IconClasses.Contains("locked"))
			 Console.WriteLine("Icon state is LOCKED");
		else
			 Console.WriteLine("Icon state is UNLOCKED");
	}
