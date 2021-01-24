    public static FeedResponse<T> ToFeedResponse<T>(this IQueryable<T> resource, IDictionary<string, string> responseHeaders = null)
        {
            var feedResponseType = Type.GetType("Microsoft.Azure.Documents.Client.FeedResponse`1, Microsoft.Azure.DocumentDB.Core, Version=1.9.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var headers = new NameValueCollection
            {
                { "x-ms-request-charge", "0" },
                { "x-ms-activity-id", Guid.NewGuid().ToString() }
            };
            
            if (responseHeaders != null)
            {
                foreach (var responseHeader in responseHeaders)
                {
                    headers[responseHeader.Key] = responseHeader.Value;
                }
            }
            var arguments = new object[] { resource, resource.Count(), headers, false, null };
            if (feedResponseType != null)
            {
                var t = feedResponseType.MakeGenericType(typeof(T));
                var feedResponse = Activator.CreateInstance(t, flags, null, arguments, null);
                return (FeedResponse<T>)feedResponse;
            }
            return new FeedResponse<T>();
        }
    }
