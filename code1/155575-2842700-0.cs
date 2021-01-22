     // Get the response stream
     using(Stream resStream = response.GetResponseStream())
     {
    
    		string parseString = null;
    		int    count      = 0;
    
    		do
    		{
    			// Read a chunk of data
    			count = resStream.Read(buf, 0, buf.Length);
    
    			if (count != 0)
    			{
    				// Convert to ASCII
    				parseString = Encoding.ASCII.GetString(buf, 0, count);
    
    				// Append string to results
    				sb.Append(tempString);
    			}
    		}
    		while (count > 0);
    
    }
