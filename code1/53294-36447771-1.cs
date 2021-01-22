    public sealed class QueryStringBuilder
    {
        public QueryStringBuilder()
        {
            this.inner = HttpUtility.ParseQueryString(string.Empty);
        }
        public QueryStringBuilder(string queryString)
        {
            this.inner = HttpUtility.ParseQueryString(queryString);
        }
        public QueryStringBuilder(string queryString, Encoding encoding)
        {
            this.inner = HttpUtility.ParseQueryString(queryString, encoding);
        }
        private readonly NameValueCollection inner;
        public QueryStringBuilder AddKey(string key, string value)
        {
            this.inner.Add(key, value);
            return this;
        }
        public QueryStringBuilder RemoveKey(string key)
        {
            this.inner.Remove(key);
            return this;
        }
        public QueryStringBuilder Clear()
        {
            this.inner.Clear();
            return this;
        }
        public override String ToString()
        {
            if (this.inner.Count == 0)
                return string.Empty;
            var builder = new StringBuilder();
            for (int i = 0; i < this.inner.Count; i++)
            {
                if (builder.Length > 0)
                    builder.Append('&');
                var key = this.inner.GetKey(i);
                var values = this.inner.GetValues(i);
                if (key == null || values == null || values.Length == 0)
                    continue;
                for (int j = 0; j < values.Length; j++)
                {
                    if (j > 0)
                        builder.Append('&');
                    builder.Append(HttpUtility.UrlEncode(key));
                    builder.Append('=');
                    builder.Append(HttpUtility.UrlEncode(values[j]));
                }
            }
            return builder.ToString();
        }
    }
