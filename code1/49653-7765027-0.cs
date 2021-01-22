        public static string CurrentUrlWithParam(this UrlHelper helper, string paramName, string paramValue)
        {
            var url = helper.RequestContext.HttpContext.Request.Url;
            var sb = new StringBuilder();
            sb.AppendFormat("{0}://{1}{2}{3}",
                            url.Scheme,
                            url.Host,
                            url.IsDefaultPort ? "" : ":" + url.Port,
                            url.LocalPath);
            var isFirst = true;
            if (!String.IsNullOrWhiteSpace(url.Query))
            {
                var queryStrings = url.Query.Split(new[] { '?', ';' });
                foreach (var queryString in queryStrings)
                {
                    if (!String.IsNullOrWhiteSpace(queryString) && !queryString.StartsWith(paramName + "="))
                    {
                        sb.AppendFormat("{0}{1}", isFirst ? "?" : ";", queryString);
                        isFirst = false;
                    }
                }
            }
            sb.AppendFormat("{0}{1}={2}", isFirst ? "?" : ";", paramName, paramValue);
            return sb.ToString();
        }
