    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    // By Demetris Leptos
    namespace TheOperator.Foundation.Web
    {
        public class UrlBuilder
        {
            public string Scheme { get; set; }
            public string Host { get; private set; }
            public int? Port { get; set; }
            public List<string> Paths { get; set; }
            public SortedDictionary<string, string> QueryPairs { get; set; }
            public UrlBuilder(string url)
            {
                this.Paths = new List<string>();
                this.QueryPairs = new SortedDictionary<string, string>();
                var implementation = new UriBuilder(url);
                this.Host = implementation.Host;
                this.Scheme = implementation.Scheme;
                this.Paths.AddRange(implementation.Path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries));
                this.Port = implementation.Port;
                var query = HttpUtility.ParseQueryString(implementation.Query);
                foreach (var queryKey in query.AllKeys)
                {
                    this.QueryPairs[queryKey] = query[queryKey];
                }
            }
            public UrlBuilder AddPath(string value)
            {
                this.Paths.Add(value);
                return this;
            }
            public UrlBuilder SetQuery(string key, string value)
            {
                this.QueryPairs[key] = value;
                return this;
            }
            public UrlBuilder RemoveQuery(string key)
            {
                this.QueryPairs.Remove(key);
                return this;
            }
            public UrlBuilder AlterQuery(string key, Func<string, string> alterMethod, bool removeOnNull = false)
            {
                string value;
                this.QueryPairs.TryGetValue(key, out value);
                value = alterMethod(value);
                if (removeOnNull && value == null)
                {
                    return this.RemoveQuery(key);
                }
                else
                {
                    return this.SetQuery(key, value);
                }
            }
            public override string ToString()
            {
                var path = string.Join("/", this.Host, string.Join("/", this.Paths));
                var query = string.Join("&", this.QueryPairs.Select(x => string.Concat(x.Key, "=", HttpUtility.UrlEncode(x.Value))));
                return string.Concat(
                    this.Scheme,
                    "://",
                    path,
                    !string.IsNullOrWhiteSpace(query) ? string.Concat("?", query) : null);
            }
        }
    }
