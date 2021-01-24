    class Program
    {
        static HttpClient httpClient = new HttpClient();
        static void Main(string[] args)
        {
            string test1 = GetContentFromHost("test1"); // gets content from Default Web Site - "test1"
            string test2 = GetContentFromHost("test2"); // gets content from Default Web Site 2 - "test2"
        }
        static string GetContentFromHost(string host)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, "http://127.0.0.1");
            msg.Headers.Add("Host", host);
            return httpClient.SendAsync(msg).Result.Content.ReadAsStringAsync().Result;
        }
    }
