    String FinalResult = "";
    HttpWebRequest Request = (HttpWebRequest)System.Net.WebRequest.Create( URL );
    HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
    Stream ResponseStream = Response.GetResponseStream();
    StreamReader Reader = new StreamReader( ResponseStream );
    
    bool NeedEncodingCheck = true;
    
    while( true )
    {
    	string NewLine = Reader.ReadLine(); // it may not working for zipped HTML.
    	if( NewLine == null )
    	{
    		break;
    	}
    
    	FinalResult += NewLine;
    	FinalResult += Environment.NewLine;
    
    	if( NeedEncodingCheck )
    	{
    		int Start = NewLine.IndexOf( "charset=" );
    		if( Start > 0 )
    		{
    			Start += "charset=\"".Length;   
    			int End = NewLine.IndexOfAny( new[] { ' ', '\"', ';' }, Start );
    
    			Reader = new StreamReader( ResponseStream, Encoding.GetEncoding(
    				NewLine.Substring( Start, End - Start ) ) ); // Replace Reader with new encoding.
    
    			NeedEncodingCheck = false;
    		}
    	}
    }
    
    Reader.Close();
    Response.Close();
