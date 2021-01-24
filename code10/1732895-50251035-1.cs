    HtmlRow row = FindReport(reportName); // Method which finds row
	VerifyStatus(reportName, status); // Method verifies status in the row and returns true if complete
	HtmlSpan link = new HtmlSpan(row);
	
	int TimoutMilliSecond = 120000//as you told about 2 minutes for the link to be accessible
	int count = 1;
	bool ControlExist = false;
	
	while (ControlExist == false)
	{
			link.SearchProperties.Add(HtmlSpan.PropertyNames.InnerText, "Order", PropertyExpressionOperator.Contains);
			
			if (link != null)//null or in your case any bad state you get as result after the SearchProperties on 'link'
			{
				ControlExist = link.Exists;
			}
			if (count > TimoutMilliSecond)
			{
				Assert.Fail("The control '" + ControlToCheck.Name + "' with type '" + ControlToCheck.ControlType.ToString() + "' was not found within the timout set out to: " + TimoutMilliSecond.ToString() + " Milliseconds !");
			}
			Playback.Wait(100);
			count = count + 100;
	}
	if (link != null)
	{
		link.Find();
	}
