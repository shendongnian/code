    public class QueryString
    {
        static NameValueCollection QS
        {
            get
            {
                if (HttpContext.Current == null)
                    throw new ApplicationException("No HttpContext!");
                return HttpContext.Current.Request.QueryString;
            }
        }
        public static int Int(string key)
        {
            int i; 
            if (!int.TryParse(QS[key], out i))
                i = -1; // Obviously Change as you see fit.
            return i;
        }
    
        // ... Other types omitted.
    }
    // And to Use..
    void Test()
    {
        int i = QueryString.Int("test");
    }
