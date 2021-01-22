    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                var contents = client.DownloadString("http://www.google.com");
                Console.WriteLine(contents);
            }
        }
    }
