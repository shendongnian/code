    public class TestRequest
    {
        public int dataId { get; set; }
        public string ToXml() => $"<row id=\"{dataId}\"/>";
    }
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 10000000;
            List<TestRequest> ids = new List<TestRequest>();
            Random rnd = new Random();
            for (int i = 1; i<n; i++)
            {
                var data = new TestRequest
                {
                    dataId=rnd.Next(1, 12345)
                };
                ids.Add(data);
            }
            Stopwatch sw = Stopwatch.StartNew();
            var xml = GetIdsinXML(ids);
            sw.Stop();
            double time = sw.Elapsed.TotalSeconds;
            File.WriteAllText("result.xml", xml);
            Process.Start("result.xml");
            var output = $"Size={n} items, Time={time} sec, Speed={n/time/1000000} M/sec";
    #if DEBUG
            Debug.WriteLine(output);
    #else
            Console.WriteLine(output);
    #endif
        }
        static string GetIdsinXML(List<TestRequest> requests)
        {
            // parallel query
            var list = requests.AsParallel().Select((item) => item.ToXml());
            // or sequential below:
            // var list = requests.Select((item) => item.ToXml());
            return $"<root>\r\n{string.Join("\r\n", list)}\r\n</root>";
        }
    }
