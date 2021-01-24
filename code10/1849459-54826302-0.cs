	string url = string.Format("https://example.com/api/mytext");
	System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
	req.Method = "GET";
	req.UserAgent = "mykey";
	req.Accept = "text/json";
	using (System.Net.HttpWebResponse resp = (System.Net.HttpWebResponse)req.GetResponse())
	{
		if (resp.StatusCode == System.Net.HttpStatusCode.OK)
		{
		    string contents;
			// how do I access the JSON here and loop through it?
            using(var responseStream = resp.GetResponseStream())
			using(var responseStreamReader = new StreamReader(responseStream))
			{
			    contents = responseStreamReader.ReadToEnd();
			}
			
			var deserializedContent = JsonConvert.DeserializeObject<T>(contents);
		}
	}
