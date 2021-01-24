    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                data();
                Console.ReadKey();
            }
            public static async void data()
            {
                var client = await new HttpClient().GetAsync("http://www.hkex.com.hk/eng/stat/dmstat/dayrpt/hsio180629.htm");
                var data= await client.Content.ReadAsStreamAsync();
                using (var fileStream = new FileStream("D://data.txt", FileMode.Create, FileAccess.Write))
                {
                    data.CopyTo(fileStream);
                }
            }
        }
    }
