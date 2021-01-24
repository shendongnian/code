    class Program
    {
        static void Main(string[] args)
        {
            string json =
                @"{""DiscountRate"":12.0, ""DiscountAmount"":{ ""DiscountAmountVar"":13.0 } }";
            var converted = JsonConvert.DeserializeObject<ChargesDetail>(json);
            Console.WriteLine(converted.DiscountAmount);
        }
    }
    public class ChargesDetail
    {
        public decimal DiscountRate { get; set; }
        public Amount DiscountAmount { get; set; }
    }
    public class Amount 
    {
        public decimal DiscountAmountVar { get; set; }
    }
