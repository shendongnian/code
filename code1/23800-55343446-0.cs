        public static string CombineUrl(this string root, string path, params string[] paths)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return root;
            }
            Uri baseUri = new Uri(root);
            Uri combinedPaths = new Uri(baseUri, path);
            foreach (string extendedPath in paths)
            {
               combinedPaths = new Uri(combinedPaths, extendedPath);
            }
            return combinedPaths.AbsoluteUri;
        }
        public static string AddUrlParams(this string url, Dictionary<string, string> parameters)
        {
            if (parameters == null || !parameters.Keys.Any())
            {
                return url;
            }
            var tempUrl = new StringBuilder($"{url}?");
            int count = 0;
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                if (count > 0)
                {
                    tempUrl.Append("&");
                }
                tempUrl.Append($"{WebUtility.UrlEncode(parameter.Key)}={WebUtility.UrlEncode(parameter.Value)}");
                count++;
            }
            return tempUrl.ToString();
        }
