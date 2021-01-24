    var req = (HttpWebRequest) WebRequest.Create(myUrl);
    req.MediaType = "GET";
	req.AllowAutoRedirect = false;
	try
	{
	    var rsp = req.GetResponse();
		Console.WriteLine(rsp.Headers["Location"]);
	}
	catch (WebException e)
	{
		var rsp = (HttpWebResponse) e.Response;
		if (rsp.StatusCode == HttpStatusCode.Moved ||
		    rsp.StatusCode == HttpStatusCode.MovedPermanently ||
		    rsp.StatusCode == HttpStatusCode.Found)
		{
			Console.WriteLine(rsp.Headers["Location"]);
		}
		else throw;
	}
