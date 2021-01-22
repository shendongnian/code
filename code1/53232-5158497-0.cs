        public static string ToQueryString(this Dictionary<string, string> source)
        {
            return String.Join("&", source.Select(kvp => String.Format("{0}={1}", HttpUtility.UrlEncode(kvp.Key), HttpUtility.UrlEncode(kvp.Value))).ToArray());
        }
        public static string ToQueryString(this NameValueCollection source)
        {
            return String.Join("&", source.Cast<string>().Select(key => String.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(source[key]))).ToArray());
        }
