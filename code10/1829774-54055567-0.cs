    public static class HttpClientExtensions
    {
        public static void AddHeadersFromJson(this HttpClient client, string json)
        {
            JObject obj = JObject.Parse(json);
            foreach (JProperty prop in obj["header_settings"].Children<JProperty>())
            {
                client.DefaultRequestHeaders.Add(prop.Name, (string)prop.Value);
            }
        }
    }
