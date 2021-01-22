       public static string ActionWithList(this UrlHelper helper, string action, object routeData)
        {
            RouteValueDictionary rv = new RouteValueDictionary(routeData);
            var newRv = new RouteValueDictionary();
            var arrayRv = new RouteValueDictionary();
            foreach (var kvp in rv)
            {
                var nrv = newRv;
                var val = kvp.Value;
                if (val is IEnumerable && !(val is string))
                {
                    nrv = arrayRv;
                }
                nrv.Add(kvp.Key, val);
            }
            string href = helper.Action(action, newRv);
            foreach (var kvp in arrayRv)
            {
                IEnumerable lst = kvp.Value as IEnumerable;
                var key = kvp.Key;
                foreach (var val in lst)
                {
                    href = href.AddQueryString(key, val);
                }
            }
            return href;
        }
        public static string AddQueryString(this string url, string name, object value)
        {
            url = url ?? "";
            char join = '?';
            if (url.Contains('?'))
                join = '&';
            return string.Concat(url, join, name, "=", HttpUtility.UrlEncode(value.ToString()));
        }
