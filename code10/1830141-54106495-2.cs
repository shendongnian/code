    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            HttpContent content = new StreamContent(File.OpenRead(@"2.png"));
            Task.WaitAll(client.PostAsync("http://10.157.18.36:8800/service1.svc/UploadStream", content));
            Console.WriteLine("OK");
        }
    }
