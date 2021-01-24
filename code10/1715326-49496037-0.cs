    namespace ConsoleApplication8
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = "{\"Date\":\"2018-03-23\",\"Requests\":\"24,992\",\"Price\":\"95.96\"}";
                PriceModel value = JsonConvert.DeserializeObject<PriceModel>(json);
                Console.ReadLine();
            }
        }
        public class PriceModel
        {
            public DateTime Date { get; set; }
            public int RequestsInt { get; set; }
            public string Requests
            {
                set
                {
                    int num;
                    if (int.TryParse(value, NumberStyles.AllowThousands,
                                     CultureInfo.InvariantCulture, out num))
                    {
                        RequestsInt = num;
                    }
                }
            }
            public decimal Price { get; set; }
        }
   
    }
