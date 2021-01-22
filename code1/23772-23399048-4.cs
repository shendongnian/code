        public static string Combine(params string[] parts)
        {
            if (parts == null || parts.Length == 0) return string.Empty;
            var urlBuilder = new StringBuilder();
            foreach (var part in parts)
            {
                var tempUrl = tryCreateRelativeOrAbsolute(part);
                urlBuilder.Append(tempUrl);
            }
            return VirtualPathUtility.RemoveTrailingSlash(urlBuilder.ToString());
        }
        private static string tryCreateRelativeOrAbsolute(string s)
        {
            System.Uri uri;
            System.Uri.TryCreate(s, UriKind.RelativeOrAbsolute, out uri);
            string tempUrl = VirtualPathUtility.AppendTrailingSlash(uri.ToString());
            return tempUrl;
        }
