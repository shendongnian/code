    public void SendRequest()
	{
		var response = "Testing123...";
		// Form the request here...
		if (response.Contains("Special Keyword"))
		{			
			SendRequest();
		}
		
	}
