        public string ToQueryString(NameValueCollection nvc)
        {
            StringBuilder sb = new StringBuilder("?");
            bool first = true;
            foreach (string key in nvc.AllKeys)
            {
                foreach (string value in nvc.GetValues(key))
                {
                    if (!first)
                    {
                        sb.Append("&");
                    }
                    sb.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));
                    first = false;
                }
            }
            return sb.ToString();
        }
