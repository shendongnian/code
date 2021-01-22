    public static class HttpExtensions
    {
    	public static string ToQueryString(this NameValueCollection collection)
    	{
    		// This is based off the NameValueCollection.ToString() implementation
    		int count = collection.Count;
    		if (count == 0)
    			return string.Empty;
    
    		StringBuilder stringBuilder = new StringBuilder();
    
    		for (int i = 0; i < count; i++)
    		{
    			string text = collection.GetKey(i);
    			text = HttpUtility.UrlEncodeUnicode(text);
    			string value = (text != null) ? (text + "=") : string.Empty;
    			string[] values = collection.GetValues(i);
    			if (stringBuilder.Length > 0)
    			{
    				stringBuilder.Append('&');
    			}
    			if (values == null || values.Length == 0)
    			{
    				stringBuilder.Append(value);
    			}
    			else
    			{
    				if (values.Length == 1)
    				{
    					stringBuilder.Append(value);
    					string text2 = values[0];
    					text2 = HttpUtility.UrlEncodeUnicode(text2);
    					stringBuilder.Append(text2);
    				}
    				else
    				{
    					for (int j = 0; j < values.Length; j++)
    					{
    						if (j > 0)
    						{
    							stringBuilder.Append('&');
    						}
    						stringBuilder.Append(value);
    						string text2 = values[j];
    						text2 = HttpUtility.UrlEncodeUnicode(text2);
    						stringBuilder.Append(text2);
    					}
    				}
    			}
    		}
    
    		return stringBuilder.ToString();
    	}
    }
