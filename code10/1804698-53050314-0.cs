    // you should share this for connection pooling  
    public static HttpClient = new HttpClient();
    public static void Main(string[] args)
    {
        // build a list of tasks to wait on, then wait
        var tasks = ss.Select(x => metadataApi(url, conn, name, alias)).ToArray();
        Task.WaitAll(tasks);
    }
    public static async Task metadataApi(string _url, string _connstring, string _spname, string _alias)
    {
        string url = _url;
        var response = await httpClient.GetAsync(url);
        Console.WriteLine("CHECKING");
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("IS OK");
            string json = await content.ReadAsStringAsync();
            //Doing some stuff not relevant
        }
    }
