        public static string CurrentUrlWithParam(this UrlHelper helper, string paramName, string paramValue)
        {
            var url = helper.RequestContext.HttpContext.Request.Url;
            var ub = new UriBuilder(url.Scheme, url.Host, url.Port, url.LocalPath);
            // Query string
            var sb = new StringBuilder();
            var isFirst = true;
            if (!String.IsNullOrWhiteSpace(url.Query))
            {
                var queryStrings = url.Query.Split(new[] { '?', ';' });
                foreach (var queryString in queryStrings.Where(queryString => !String.IsNullOrWhiteSpace(queryString) && !queryString.StartsWith(paramName + "=")))
                {
                    sb.AppendFormat("{0}{1}", isFirst ? "" : ";", queryString);
                    isFirst = false;
                }
            }
            sb.AppendFormat("{0}{1}={2}", isFirst ? "" : ";", paramName, paramValue);
            ub.Query = sb.ToString();
            return ub.ToString();
        }
