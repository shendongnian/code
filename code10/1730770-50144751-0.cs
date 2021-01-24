    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Debug.WriteLine("1");
            new Runner().Run().Wait();
            System.Diagnostics.Debug.WriteLine("4");
        }
    }
    public class Runner
    {
        public async Task Run()
        {
            var hc = new HttpClient();
            System.Diagnostics.Debug.WriteLine("2");
            var result = await hc.GetStringAsync("http://www.google.com");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("3");
        }
    }
