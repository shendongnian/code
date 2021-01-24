    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Stream client = Task.Run(()=>new HttpClient().GetAsync("http://www.hkex.com.hk/eng/stat/dmstat/dayrpt/hsio180629.htm").Result.Content.ReadAsStreamAsync()).Result;
                using (var fileStream = new FileStream("D://data.txt", FileMode.Create, FileAccess.Write))
                {
                    client.CopyTo(fileStream);
                }
            }
        }
    }
