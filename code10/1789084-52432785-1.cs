    public class CustomAttribute : OrderAttribute
    {
        public CustomAttribute([CallerLineNumber]int order = 0) : base(order)
        {
        }
        public string Name { get; set; }
        public bool Ignore { get; set; }
        public override int Order { get; set; } = -1;
    }
    public abstract class OrderAttribute : Attribute
    {
        private readonly int _classOrder;
        public OrderAttribute([CallerLineNumber]int order = 0)
        {
            _classOrder = order;
        }
        public int ClassOrder { get { return _classOrder;  } }
        public virtual int Order { get; set; }
    }
