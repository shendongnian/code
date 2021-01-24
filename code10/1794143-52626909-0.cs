	public static string Get(Uri uri, string token)
	{
		string responseString = string.Empty;
		HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
		request.Method = "GET";
		request.ContentType = "application/json;charset=utf-8";
		request.Headers.Add("Authorization", string.Format("Bearer {0}", token));
		using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
		{
			using (Stream responseStream = response.GetResponseStream())
			{
				StreamReader responseReader = new StreamReader(responseStream);
				responseString = responseReader.ReadToEnd();
			}
		}
		return responseString;
	}
