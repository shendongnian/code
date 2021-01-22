    namespace System.Web.Mvc
    {
        public static class ViewPageExtensions
        {
            public static string GetDefaultPageTitle<T>(this ViewPage<T> v)
            {
                return "";
            }
        }
    }
