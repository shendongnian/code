    public class Program
    {
        static void Main(string[] args)
        {
            var json = @"{'Amount':'1.096E8'}";
            var amount = JsonConvert.DeserializeObject<MyClassName>(json);
        }
    }
