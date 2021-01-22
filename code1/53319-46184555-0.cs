        public static Dictionary<string, string> QueryParametersDictionary()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("name", "John Doe");
            dictionary.Add("address.city", "Seattle");
            dictionary.Add("address.state_code", "WA");
            dictionary.Add("api_key", "5352345263456345635");
            return dictionary;
        }
        public static string ToQueryString(Dictionary<string, string> nvc)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (KeyValuePair<string, string> pair in nvc)
            {
                    if (!first)
                    {
                        sb.Append("&");
                    }
                    sb.AppendFormat("{0}={1}", Uri.EscapeDataString(pair.Key), Uri.EscapeDataString(pair.Value));
                    first = false;
            }
            return sb.ToString();
        }
