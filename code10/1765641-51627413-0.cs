    public class Order : AggregateRootBase<OrderId>
    {
        private readonly IList<OrderItem> _items;
        public string CustomerName { get; private set; }
        public DateTime RegisterDatetime { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => new ReadOnlyCollection<OrderItem>(_items);
    }
    public class OrderItem : ValueObjectBase
    {
        private readonly long _number;
        private readonly long _goods;
        private readonly double _unitPrice;
        public long Number => _number;
        public long Goods => _goods;
        public double UnitPrice => _unitPrice;
    }
