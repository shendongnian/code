        public class UriTool
        {
            public static Uri JoinToUri(string path1, string path2)
            {
                string url = path1 + "/" + path2;
                url = Regex.Replace(url, "(?<!http:)/{2,}", "/");
                return new Uri();
            }
        }
