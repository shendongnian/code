    const string WEBSERVICE_URL = "http://localhost/projectname/ServiceName.svc/ServiceMethod";
    //This string is untested, but I think it's ok.
    string jsonData = "{ \"key1\" : \"value1\", \"key2\":\"value2\"  }"; 
    try
    {		
    	var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
    	if (webRequest != null)
    	{
    		webRequest.Method = "POST";
    		webRequest.Timeout = 20000;
    		webRequest.ContentType = "application/json";
		using (System.IO.Stream s = webRequest.GetRequestStream())
		{
			using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
				sw.Write(jsonData);
		}
		using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
		{
			using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
			{
				var jsonResponse = sr.ReadToEnd();
				System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
			}
		}
	}
    }
    catch (Exception ex)
    {
    	System.Diagnostics.Debug.WriteLine(ex.ToString());
    }
