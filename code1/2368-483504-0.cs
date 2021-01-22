    public OrderItemCollection : IEnumerable<OrderItem> 
    {
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
    
        void Add(OrderItem item)
        {
             _orderItems.Add(item)
        }
        //implement only the list members, which are required from your domain. 
        //ie. sum items, calculate weight etc...
        private IEnumerator<string> Enumerator() {
            return _orderItems.GetEnumerator();
        }
        public IEnumerator<string> GetEnumerator() {
            return Enumerator();
        }    
    }
