    HttpWebRequest downloadRequest = WebRequest.Create(downloadUri) as HttpWebRequest;
    using(HttpWebResponse downloadResponse = downloadRequest.GetResponse() as HttpWebResponse)
    {
    	HttpWebRequest uploadRequest = new HttpWebRequest(uploadUri);
    	uploadRequest.Method = "POST";
    	uploadRequest.ContentLength = downloadResponse.ContentLength;
        using (Stream downloadStream = downloadResponse.GetResponseStream())
    	using (Stream uploadStream = downloadResponse.GetRequestStream())
    	{
        	byte[] buffer = new byte[4096];
    		int totalBytes = 0;
    		while(totalBytes < downloadResponse.ContentLength)
    		{
    			int nBytes = downloadStream.Read(buffer, 0, buffer.Length);
    			uploadStream.Write(buffer, 0, nBytes);
    			totalBytes += nRead;
    		}
    	}
    	HttpWebResponse uploadResponse = uploadRequest.GetResponse() as HttpWebResponse;
    	uploadResponse.Close();
    }
