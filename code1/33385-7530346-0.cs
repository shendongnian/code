        public static string GetQueryStringWithOutParameter(string parameter)
        {
            var nameValueCollection = System.Web.HttpUtility.ParseQueryString(HttpContext.Current.Request.QueryString.ToString());
            nameValueCollection.Remove(parameter);
            string url = HttpContext.Current.Request.Path + "?" + nameValueCollection;
            return url;
        }
