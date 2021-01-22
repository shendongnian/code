    public static string DownloadString(string address)
    {
    	string strWebPage = "";
    	// create request
    	System.Net.WebRequest objRequest = System.Net.HttpWebRequest.Create(address);
    	// get response
    	System.Net.HttpWebResponse objResponse;
    	objResponse = (System.Net.HttpWebResponse)objRequest.GetResponse();
    	// get correct charset and encoding from the server's header
    	string Charset = objResponse.CharacterSet;
    	Encoding encoding = Encoding.GetEncoding(Charset);
    	// read response into memory stream
    	MemoryStream memoryStream;
    	using (Stream responseStream = objResponse.GetResponseStream())
    	{
    		memoryStream = new MemoryStream();
    		byte[] buffer = new byte[1024];
    		int byteCount;
    		do
    		{
    			byteCount = responseStream.Read(buffer, 0, buffer.Length);
    			memoryStream.Write(buffer, 0, byteCount);
    		} while (byteCount > 0);
    	}
    	// set stream position to beginning
    	memoryStream.Seek(0, SeekOrigin.Begin);
    	StreamReader sr = new StreamReader(memoryStream, encoding);
    	strWebPage = sr.ReadToEnd();
    	// Check real charset meta-tag in HTML
    	int CharsetStart = strWebPage.IndexOf("charset=");
    	if (CharsetStart > 0)
    	{
    		CharsetStart += 8;
    		int CharsetEnd = strWebPage.IndexOfAny(new[] { ' ', '\"', ';' }, CharsetStart);
    		string RealCharset =
    			   strWebPage.Substring(CharsetStart, CharsetEnd - CharsetStart);
    		// real charset meta-tag in HTML differs from supplied server header???
    		if (RealCharset != Charset)
    		{
    			// get correct encoding
    			Encoding CorrectEncoding = Encoding.GetEncoding(RealCharset);
    			// reset stream position to beginning
    			memoryStream.Seek(0, SeekOrigin.Begin);
    			// reread response stream with the correct encoding
    			StreamReader sr2 = new StreamReader(memoryStream, CorrectEncoding);
    			strWebPage = sr2.ReadToEnd();
    			// Close and clean up the StreamReader
    			sr2.Close();
    		}
    	}
    	// dispose the first stream reader object
    	sr.Close();
    	return strWebPage;
    }
