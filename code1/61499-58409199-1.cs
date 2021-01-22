    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>
            {
                new Order
                {
                    OrderID = "orderID1",
                    OrderLines = new List<OrderLine>
                    {
                        new OrderLine
                        {
                            ProductSKU = "SKU1",
                            Quantity = 1
                        },
                        new OrderLine
                        {
                            ProductSKU = "SKU2",
                            Quantity = 2
                        },
                        new OrderLine
                        {
                            ProductSKU = "SKU3",
                            Quantity = 3
                        }
                    }
                },
                new Order
                {
                    OrderID = "orderID2",
                    OrderLines = new List<OrderLine>
                    {
                        new OrderLine
                        {
                            ProductSKU = "SKU4",
                            Quantity = 4
                        },
                        new OrderLine
                        {
                            ProductSKU = "SKU5",
                            Quantity = 5
                        }
                    }
                }
            };
            //required result is the list of all SKUs in orders
            List<string> allSKUs = new List<string>();
            //With Select case 2 foreach loops are required
            var flattenedOrdersLinesSelectCase = orders.Select(o => o.OrderLines);
            foreach (var flattenedOrderLine in flattenedOrdersLinesSelectCase)
            {
                foreach (OrderLine orderLine in flattenedOrderLine)
                {
                    allSKUs.Add(orderLine.ProductSKU);
                }
            }
            //With SelectMany case only one foreach loop is required
            allSKUs = new List<string>();
            var flattenedOrdersLinesSelectManyCase = orders.SelectMany(o => o.OrderLines);
            foreach (var flattenedOrderLine in flattenedOrdersLinesSelectManyCase)
            {
                allSKUs.Add(flattenedOrderLine.ProductSKU);
            }
           //If the required result is flattened list which has OrderID, ProductSKU and Quantity,
           //SelectMany with selector is very helpful to get the required result
           //and allows avoiding own For loops what according to my experience do code faster when
           // hundreds of thousands of data rows must be operated
            List<OrderLineForReport> ordersLinesForReport = (List<OrderLineForReport>)orders.SelectMany(o => o.OrderLines,
                (o, ol) => new OrderLineForReport
                {
                    OrderID = o.OrderID,
                    ProductSKU = ol.ProductSKU,
                    Quantity = ol.Quantity
                }).ToList();
        }
    }
    class Order
    {
        public string OrderID { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
    class OrderLine
    {
        public string ProductSKU { get; set; }
        public int Quantity { get; set; }
    }
    class OrderLineForReport
    {
        public string OrderID { get; set; }
        public string ProductSKU { get; set; }
        public int Quantity { get; set; }
    }
