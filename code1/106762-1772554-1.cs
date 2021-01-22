    public interface IRule { }
    
    [Export(typeof(IRule))]
    [ExportMetadata("Order", 1)]
    public class Rule1 : IRule { }
    
    [Export(typeof(IRule))]
    [ExportMetadata("Order", 2)]
    public class Rule2 : IRule { }
    
    public interface IOrderMetadata
    {
        [DefaultValue(Int32.MaxValue)]
        int Order { get; }
    }
    
    public class Engine
    {
        public Engine()
        {
            Rules = new OrderingCollection<IRule, IOrderMetadata>(
                               lazyRule => lazyRule.Metadata.Order);
        }
    
        [ImportMany]
        public OrderingCollection<IRule, IOrderMetadata> Rules { get; set; }
    }
