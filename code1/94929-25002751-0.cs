        public static string EnsureUrlEndsWithSlash(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");
            if (!url.EndsWith("/"))
                return string.Concat(url, "/");
            return url;
        }
        public static string GetQueryStringFromArray(KeyValuePair<string, string>[] values)
        {
            Dictionary<string, string> dValues = new Dictionary<string,string>();
            foreach(var pair in values)            
                dValues.Add(pair.Key, pair.Value);            
            var array = (from key in dValues.Keys select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(dValues[key]))).ToArray();
            return "?" + string.Join("&", array);
        }
        public static void RedirectTo(this HttpRequestBase request, string url, params KeyValuePair<string, string>[] queryParameters)
        {            
            string redirectUrl = string.Concat(EnsureUrlEndsWithSlash(url), GetQueryStringFromArray(queryParameters));
            if (request.IsAjaxRequest())
                HttpContext.Current.Response.Write(string.Format("<script type=\"text/javascript\">window.location='{0}';</script>", redirectUrl));
            else
                HttpContext.Current.Response.Redirect(redirectUrl, true);
            
        }
