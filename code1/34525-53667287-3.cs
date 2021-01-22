    namespace Example
    {
    	using System;
    	using System.Text;
    	
    	public static class StringExtensions
    	{
    		public static int CountSubstr(this string str, string substr)
    		{
    			return (str.Length - str.Replace(substr, "").Length) / substr.Length;
    		}
    
    		public static int CountSubstr(this string str, char substr)
    		{
    			return (str.Length - str.Replace(substr.ToString(), "").Length);
    		}
    
    		public static int CountSubstr2(this string str, string substr)
    		{
    			int substrlen = substr.Length;
    			int lastIndex = str.IndexOf(substr, 0, StringComparison.Ordinal);
    			int count = 0;
    			while (lastIndex != -1)
    			{
    				++count;
    				lastIndex = str.IndexOf(substr, lastIndex + substrlen, StringComparison.Ordinal);
    			}
    
    			return count;
    		}
    
    		public static int CountSubstr2(this string str, char substr)
    		{
    			int lastIndex = str.IndexOf(substr, 0);
    			int count = 0;
    			while (lastIndex != -1)
    			{
    				++count;
    				lastIndex = str.IndexOf(substr, lastIndex + 1);
    			}
    
    			return count;
    		}
    
    		public static int CountChar(this string str, char substr)
    		{
    			int length = str.Length;
    			int count = 0;
    			for (int i = 0; i < length; ++i)
    				if (str[i] == substr)
    					++count;
    
    			return count;
    		}
    
    		public static int CountChar2(this string str, char substr)
    		{
    			int count = 0;
    			foreach (var c in str)
    				if (c == substr)
    					++count;
    
    			return count;
    		}
    
    		public static unsafe int CountChar3(this string str, char substr)
    		{
    			int length = str.Length;
    			int count = 0;
    			fixed (char* chars = str)
    			{
    				for (int i = 0; i < length; ++i)
    					if (*(chars + i) == substr)
    						++count;
    			}
    
    			return count;
    		}
    
    		public static unsafe int CountChar4(this string str, char substr)
    		{
    			int length = str.Length;
    			int count = 0;
    			fixed (char* chars = str)
    			{
    				for (int i = length - 1; i >= 0; --i)
    					if (*(chars + i) == substr)
    						++count;
    			}
    
    			return count;
    		}
    
    		public static unsafe int CountSubstr3(this string str, string substr)
    		{
    			int length = str.Length;
    			int substrlen = substr.Length;
    			int count = 0;
    			fixed (char* strc = str)
    			{
    				fixed (char* substrc = substr)
    				{
    					int n = 0;
    
    					for (int i = 0; i < length; ++i)
    					{
    						if (*(strc + i) == *(substrc + n))
    						{
    							++n;
    							if (n == substrlen)
    							{
    								++count;
    								n = 0;
    							}
    						}
    						else
    							n = 0;
    					}
    				}
    			}
    
    			return count;
    		}
    
    		public static int CountSubstr3(this string str, char substr)
    		{
    			return CountSubstr3(str, substr.ToString());
    		}
    
    		public static unsafe int CountSubstr4(this string str, string substr)
    		{
    			int length = str.Length;
    			int substrLastIndex = substr.Length - 1;
    			int count = 0;
    			fixed (char* strc = str)
    			{
    				fixed (char* substrc = substr)
    				{
    					int n = substrLastIndex;
    
    					for (int i = length - 1; i >= 0; --i)
    					{
    						if (*(strc + i) == *(substrc + n))
    						{
    							if (--n == -1)
    							{
    								++count;
    								n = substrLastIndex;
    							}
    						}
    						else
    							n = substrLastIndex;
    					}
    				}
    			}
    
    			return count;
    		}
    
    		public static int CountSubstr4(this string str, char substr)
    		{
    			return CountSubstr4(str, substr.ToString());
    		}
    	}
    }
