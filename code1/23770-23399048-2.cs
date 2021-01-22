        public static string Combine(params string[] parts)
        {
            if (parts == null || parts.Length == 0) return string.Empty;
            string part0 = parts[0];
            string tempUrl = tryCreateRelativeOrAbsolute(part0);
            var urlBuilder = new StringBuilder(tempUrl);
            for (int x = 1; x < parts.Length; x++)
            {
                tempUrl = tryCreateRelativeOrAbsolute(parts[x]);
                urlBuilder.Append(tempUrl);
            }
            return VirtualPathUtility.RemoveTrailingSlash(urlBuilder.ToString());
        }
        private static string tryCreateRelativeOrAbsolute(string s)
        {
            System.Uri uri;
            TryCreate(s, UriKind.RelativeOrAbsolute, out uri);
            string tempUrl = VirtualPathUtility.AppendTrailingSlash(uri.ToString());
            return tempUrl;
        }
