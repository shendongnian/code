    static void Main(string[] args)
    {
        using (var client = new HttpClient())
        {
            var uri = new Uri("https://jsonplaceholder.typicode.com/posts/1");
            using (var response = client.GetAsync(uri).Result)
            {
                var task = response.Content.ReadAsStringAsync();
                var sp = ServicePointManager.FindServicePoint(uri);
                var ht = (Hashtable)GetPrivateField(sp, "m_ConnectionGroupList");
                var connectionGroup = ht.Values.Cast<object>().First();
                var connectionList = (ArrayList)GetPrivateField(connectionGroup, "m_ConnectionList");
                var connection = connectionList[0];
                var tlsStream = GetPrivateProperty(connection, "NetworkStream");
                var state = GetPrivateField(tlsStream, "m_Worker");
                var protocol = (SslProtocols)GetPrivateProperty(state, "SslProtocol");
                Console.WriteLine(protocol);
                Console.WriteLine(task.Result);
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
