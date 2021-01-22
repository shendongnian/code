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
            public string Host { get; set; }
            public int? Port { get; set; }
            public List<string> Paths { get; set; }
            public SortedDictionary<string, string> QueryPairs { get; set; }
            public UrlBuilder(string url)
            {
                this.Paths = new List<string>();
                this.QueryPairs = new SortedDictionary<string, string>();
                string path = null;
                string query = null;
                Uri relativeUri = null;
                if (!Uri.TryCreate(url, UriKind.Relative, out relativeUri))
                {
                    var uriBuilder = new UriBuilder(url);
                    this.Scheme = uriBuilder.Scheme;
                    this.Host = uriBuilder.Host;
                    this.Port = uriBuilder.Port;
                    path = uriBuilder.Path;
                    query = uriBuilder.Query;
                }
                else
                {
                    var queryIndex = url.IndexOf('?');
                    if (queryIndex >= 0)
                    {
                        path = url.Substring(0, queryIndex);
                        query = url.Substring(queryIndex + 1);
                    }
                    else
                    {
                        path = url;
                    }
                }
                this.Paths.AddRange(path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries));
                if (query != null)
                {
                    var queryKeyValuePairs = HttpUtility.ParseQueryString(query);
                    foreach (var queryKey in queryKeyValuePairs.AllKeys)
                    {
                        this.QueryPairs[queryKey] = queryKeyValuePairs[queryKey];
                    }
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
                var path = !string.IsNullOrWhiteSpace(this.Host)
                    ? string.Join("/", this.Host, string.Join("/", this.Paths))
                    : string.Join("/", this.Paths);
                var query = string.Join("&", this.QueryPairs.Select(x => string.Concat(x.Key, "=", HttpUtility.UrlEncode(x.Value))));
                return string.Concat(
                    !string.IsNullOrWhiteSpace(this.Scheme) ? string.Concat(this.Scheme, "://") : null,
                    path,
                    !string.IsNullOrWhiteSpace(query) ? string.Concat("?", query) : null);
            }
        }
    }
