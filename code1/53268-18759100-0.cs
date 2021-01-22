    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class QueryStringBuilder : List<KeyValuePair<string, object>>
    {
        public void Add(string name, object value)
        {
            Add(new KeyValuePair<string, object>(name, value));
        }
        public override string ToString()
        {
            return String.Join("&", this.Select(kvp => String.Concat(HttpUtility.UrlEncode(kvp.Key), "=", HttpUtility.UrlEncode(kvp.Value.ToString()))));
        }
    }
