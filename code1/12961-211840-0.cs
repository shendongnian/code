    interface IImmutable
    {
        public string ValuableCustomerData { get; }
    }
    
    class Mutable, IImmutable
    {
        public string ValuableCustomerData { get; set; }
    }
    
    public class Immy
    {
        private List<Mutable> _mutableList = new List<Mutable>();
        public IEnumerable<IImmutable> ImmutableItems
        {
            get { return _mutableList.Cast<IMutable>(); }
        }
    }
