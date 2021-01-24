    namespace ExtensionMethods
    {
    	public static class MyExtensions
    	{
    		/// <summary>
    		/// Get the nth item from a delimited string.
    		/// </summary>
    		/// <param name="s">The string to retrieve a delimited item from.</param>
    		/// <param name="delimiter">The character used as the item delimiter.</param>
    		/// <param name="n">Zero-based index of item to return.</param>
    		/// <returns>The nth item or an empty string.</returns>
    		public static string Split(this string s, char delimiter, int n)
    		{
    
    			int pos = pos = s.IndexOf(delimiter);
    
    			if (n == 0 || pos < 0)
    			{ return (pos >= 0) ? s.Substring(0, pos) : s; }
    
    			int nDelims = 1;
    
    			while (nDelims < n && pos >= 0)
    			{
    				pos = s.IndexOf(delimiter, pos + 1);
    				nDelims++;
    			}
    
    			string result = "";
    
    			if (pos >= 0)
    			{
    				int nextDelim = s.IndexOf(delimiter, pos + 1);
    				result = (nextDelim < 0) ? s.Substring(pos + 1) : s.Substring(pos + 1, nextDelim - pos - 1);
    			}
    
    			return result;
    		}
    
    	}
    }
