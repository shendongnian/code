	using System.Text;
	namespace System.Web.Mvc.Html
	{
	    public static class HtmlHelpers
	    {
	        public static string Delimit(
                 this HtmlHelper h, string delimiter, params string[] s)
	        {
	            bool flag = false;
	            StringBuilder b = new StringBuilder();
	            for (int i = 0; i < s.Length; i++)
	                if (s[i].Length > 0)
	                    if (flag)
	                        b.Append(delimiter + s[i]);
	                    else
	                    {
	                        flag = true;
	                        b.Append(s[i]);
	                    }
	            return b.ToString();
	        }
	    }
	}
