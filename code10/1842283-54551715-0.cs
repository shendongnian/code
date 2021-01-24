    public class Wrapper
    {
        public IRepository Orders { get; }
        public IRepository Deliveries { get; }
        public IRepository Products { get; }
        public Wrapper(IRepository orders, IRepository deliveries, IRepository products)
        {
            Orders = orders;
            Deliveries = deliveries;
            Products = products
        }
    }
