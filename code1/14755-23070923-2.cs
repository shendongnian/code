    public static class HttpWebRequestExtensions
    {
        static string[] RestrictedHeaders = new string[] {
                "Accept",
                "Connection",
                "Content-Length",
                "Content-Type",
                "Date",
                "Expect",
                "Host",
                "If-Modified-Since",
                "Range",
                "Referer",
                "Transfer-Encoding",
                "User-Agent", 
                "Proxy-Connection"
        };
        static Dictionary<string, PropertyInfo> HeaderProperties = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);
        static HttpWebRequestExtensions()
        {
            Type type = typeof(HttpWebRequest);
            foreach (string header in RestrictedHeaders)
            {
                string propertyName = header.Replace("-", "");
                PropertyInfo headerProperty = type.GetProperty(propertyName);
                HeaderProperties[header] = headerProperty;
            }
        }
        public static void SetRawHeader(this HttpWebRequest request, string name, string value)
        {
            if (HeaderProperties.ContainsKey(name))
            {
                HeaderProperties[name].SetValue(request, value, null);
            }
            else
            {
                request.Headers[name] = value;
            }
        }
    }
