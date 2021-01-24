    static void Main(string[] args)
    {
        using (var client = new HttpClient())
        {
            using (var response = client.GetAsync("https://example.com/").Result)
            {
                if (response.Content is StreamContent)
                {
                    var webExceptionWrapperStream = GetPrivateField(response.Content, "content");
                    var connectStream = GetBasePrivateField(webExceptionWrapperStream, "innerStream");
                    var connection = GetPrivateProperty(connectStream, "Connection");
                    var tlsStream = GetPrivateProperty(connection, "NetworkStream");
                    var state = GetPrivateField(tlsStream, "m_Worker");
                    var protocol = (SslProtocols)GetPrivateProperty(state, "SslProtocol");
                    Console.WriteLine(protocol);
                }
                else
                {
                    // not sure if this is possible
                }
            }
        }
    }
    private static object GetPrivateProperty(object obj, string property)
    {
        return obj.GetType().GetProperty(property, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(obj);
    }
    private static object GetPrivateField(object obj, string field)
    {
        return obj.GetType().GetField(field, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(obj);
    }
    private static object GetBasePrivateField(object obj, string field)
    {
        return obj.GetType().BaseType.GetField(field, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(obj);
    }
