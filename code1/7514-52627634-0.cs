    // Html encode/decode
    	public static string HtmDecode(this string htmlEncodedString)
        {
            if(htmlEncodedString.Length > 0)
    		{
          		return System.Net.WebUtility.HtmlDecode(htmlEncodedString);
       		}
    		else
    		{
        		return htmlEncodedString;
       		}
        }
    	
    	public static string HtmEncode(this string htmlDecodedString)
        {
    		if(htmlDecodedString.Length > 0)
    		{
          		return System.Net.WebUtility.HtmlEncode(htmlDecodedString);
       		}
    		else
    		{
    			return htmlDecodedString;
       		}
        }
