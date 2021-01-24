    public class OrderProfile : Profile
        {
            public OrderProfile()
            {
                CreateMap<CreateOrderDTO, Order>().ForMember(c => c.OrderProducts, m => m.MapFrom(l => CreateOrderProducts(l.ProductIds)));
            }
    
            private static List<OrderProduct> CreateOrderProducts(IList<long> productIds)
            {
                IList<OrderProduct> orderProducts = new List<OrderProduct>();
    
                foreach (long id in productIds)
                {
                    orderProducts.Add(new OrderProduct
                    {
                        ProductId = id
                    });
                }
    
                return orderProducts.ToList();
            }
        }
