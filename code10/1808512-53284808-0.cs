	public static T GetResource<T>(string url)
	{
      var response = Encoding.UTF8.GetString(webClient.DownloadData(url));
   	  T obj = JsonConvert.DeserializeObject<T>(response);
	  return obj;
    }
    
