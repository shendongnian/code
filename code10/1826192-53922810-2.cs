	/// <summary>
	/// Get Response Text from url
	/// </summary>
	/// <param name="url"></param>
	/// <returns></returns>
	private static string GetResponseText(string url)
	{
		string text = null;
		try
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.AutomaticDecompression = DecompressionMethods.GZip;
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream))
			{
				text = reader.ReadToEnd();
			}
		}
		catch (Exception e)
		{
			//should handle this exception
		}
		return text;
	}
	
	
