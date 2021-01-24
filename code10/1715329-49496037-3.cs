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
    
