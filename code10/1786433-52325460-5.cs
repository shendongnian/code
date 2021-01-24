    static void Main(string[] args)
            {
                var mapper = MappingConfig.Configure().CreateMapper();
    
                CreateOrderDTO dto = new CreateOrderDTO
                {
                    Id = 1,
                    ProductIds = new List<long> { 23L }
                };
    
                // Here it appears that it's as if you didn't do any manual mapping.
            Order order = mapper.Map<CreateOrderDTO, Order>(dto);
                Order order = mapper.Map<CreateOrderDTO, Order>(dto);
    
                Console.WriteLine("Order Id: " + order.Id);
            Console.WriteLine("Product Id: " + order.OrderProducts.Select(o => o.ProductId).First());
            Console.ReadLine();
            }
