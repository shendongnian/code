        public enum pages { LoggedOut, Login, Home }
        static Dictionary<pages, string> pageDict = new Dictionary<pages, string>() {
            {pages.Home, "Home.aspx"},
            {pages.Login, "Login.aspx"},
            {pages.LoggedOut, "LoggedOut.aspx"}
        };
        public static string getPage(pages pageName)
        {
            return pageDict[pageName];
        }
