    public static class Utils
    {
        private static HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }
        
        public static string DoThing(string input)
        {
            // here you can access session variables like you're used to:
            Session["foo"] = input;
        }
    }
