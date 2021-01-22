    byte[] buf = new byte[8192];
    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(path);
    webRequest.KeepAlive = false;
    string content = string.Empty;
    HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
    if (!(webResponse.StatusCode == HttpStatusCode.OK))
    	if (_log.IsErrorEnabled) _log.Error(string.Format("Url {0} not found", path));
    
    Stream resStream = webResponse.GetResponseStream();
    
    int count = 0;
    do
    {
    	count = resStream.Read(buf, 0, buf.Length);
    	if (count != 0)
    	{
    		content += encoding.GetString(buf, 0, count);
    	}
    }
    while (count > 0);
