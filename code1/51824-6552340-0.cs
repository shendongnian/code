        public string GetEncodedQueryString(string key)
        {
            string query = Request.QueryString[key];
            if (query != null)
                if (query.Contains((char)0xfffd))
                    query = HttpUtility.ParseQueryString(Request.Url.Query, Encoding.GetEncoding("iso-8859-1"))[key];
            return query;
        }
