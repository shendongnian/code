    namespace YourNamespace
    {
        public static class PageExtensions
        {
            public static string GetUserName(this IRazorPage view) => User.GetUserName();
        }
    }
