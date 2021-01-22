    namespace System.Web.Mvc
    {
        public static class ViewPageExtensions
        {
            public static string GetDefaultPageTitle<Type>(this ViewPage<Type> v)
            {
                return "";
            }
        }
    }
