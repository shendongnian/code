    static void Main(string[] args)
            {
                var mapper = MappingConfig.Configure().CreateMapper();
    
                CreateOrderDTO dto = new CreateOrderDTO
                {
                    Id = 1,
                    ProductIds = new List<long> { 23L }
                };
    
                Order order = mapper.Map<CreateOrderDTO, Order>(dto);
    
                Console.WriteLine(order.Id);
                Console.WriteLine(order.OrderProducts.Select(o => o.ProductId).First());
                Console.ReadKey();
            }
