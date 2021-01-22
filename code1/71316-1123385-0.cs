        private static string FixHtml(string s)
        {            
            if (s.ToLower().StartsWith("<div>"))
            {
                return FixHtml(s.Substring(5, s.Length - 5));
            }
            else if (s.ToLower().StartsWith("<p>"))
            {
                return FixHtml(s.Substring(3, s.Length - 3));
            }
            else if (s.ToLower().EndsWith("</div>"))
            {
                return FixHtml(s.Substring(0, s.Length - 6));
            }
            else if (s.ToLower().EndsWith("</p>"))
            {
                return FixHtml(s.Substring(0, s.Length - 4));
            }
            return s;
        }
 
