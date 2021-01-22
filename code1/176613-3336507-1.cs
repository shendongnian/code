    public static class HtmlHelperExtensions
    {
        public static string IncludeStyles(this HtmlHelper helper)
        {
            var styles = helper.ViewData["StyleSheets"] as IEnumerable<string>;
            var sb = new StringBuilder();
    
            if (styles != null)
            {
                foreach (var style in styles)
                {
                    sb.AppendFormat("<link rel=\"stylesheet\" href=\"/content/" + style + ".css\" />\n");
                }
            }
 
            return sb.ToString();
        }
    }
