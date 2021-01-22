        public static string replaceQueryString(System.Web.HttpRequest request, string key, string value)
        {
            System.Collections.Specialized.NameValueCollection t = HttpUtility.ParseQueryString(request.Url.Query);
            t.Set(key, value);
            return t.ToString();
        }
