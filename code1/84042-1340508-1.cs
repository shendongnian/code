    public static class Pages
    {
        private static readonly IDictionary<String, String> PageMap = null;
        private static Pages()
        {
            Pages.PageMap = new Dictionary<String, String>();
            Pages.PageMap.Add("LoggedOut", "LoggedOut.aspx");
            Pages.PageMap.Add("Login", "Login.aspx");
            Pages.PageMap.Add("Home", "Home.aspx");
        }
        public static GetPage(String pageCode)
        {
            String page;
            if (Pages.PageMap.TryGet(pageCode, out page)
            {
                return page;
            }
            else
            {
                throw new ArgumentException("Page code not found.");
            }
        }
    }
