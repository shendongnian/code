    namespace ConsoleApplication8
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                string json = "{\"Date\":\"2018-03-23\",\"Requests\":\"24,992\",\"Price\":\"95.96\"}";
                PriceModel value = JsonConvert.DeserializeObject<PriceModelChild>(json);
            
                Console.ReadLine();
            }
        }
        public class PriceModel
        {
            public DateTime Date { get; set; }
            public int Requests { get; set; }
            public decimal Price { get; set; }
        }
        public class PriceModelChild : PriceModel
        {
            public new string Requests
            {
                set
                {
                    int num;
                    if (int.TryParse(value, NumberStyles.AllowThousands,
                        CultureInfo.InvariantCulture, out num))
                    {
                        base.Requests = num;
                    }
                }
            }
        }
    }
