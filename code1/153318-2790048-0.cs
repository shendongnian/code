    public class Test : Page
    {
        internal class QuerystringKeys : BasePage.QuerystringKeys
        {            
            public const string Page = "page";
        }
    }
    public class BasePage : Page
    {
        internal class QuerystringKeys
        {
            public const string Username = "username";
            public const string CurrentUser = "currentUser";
        }
    }
