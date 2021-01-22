        class Program
        {
            static void Main(string[] args)
            {
                List<OrderLine> ordersLines = new List<OrderLine>()
                {
                    new OrderLine {Platform = "AmazonUK", OrderId = "200-2255555-3000012", ItemTitle = "Test product 1"},
                    new OrderLine {Platform = "AmazonUK", OrderId = "200-2255555-3000013", ItemTitle = "Test product 2"},
                    new OrderLine {Platform  = "AmazonUK", OrderId = "200-2255555-3000013", ItemTitle = "Test product 3"}
                };
            }
        }
        class OrderLine
        {
            public string Platform { get; set; }
            public string OrderId { get; set; }
            public string ItemTitle { get; set; }
        }
