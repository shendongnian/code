	private string GetSSLExpiryDate(string url)
	{
		Uri u = new Uri(url);
		ServicePoint sp = ServicePointManager.FindServicePoint(u);
		string groupName = Guid.NewGuid().ToString();
		HttpWebRequest req = HttpWebRequest.Create(u) as HttpWebRequest;
		req.ConnectionGroupName = groupName;
		using (WebResponse resp = req.GetResponse())
		{
			// Ignore response, and close the response.
		}
		sp.CloseConnectionGroup(groupName);
		// Implement favourite null check pattern here on sp.Certificate
		string expiryDate = sp.Certificate.GetExpirationDateString();
		return expiryDate;
	}
