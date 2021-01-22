    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                WebClient client = new WebClient();
                client.DownloadFileAsync(new Uri("http://ipv4.download.thinkbroadband.com/5MB.zip"), "C:\\5MB.zip");
                Thread.Sleep(30000);
            }
        }
    }
