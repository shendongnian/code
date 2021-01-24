    public class From
    {
        public byte FromProperty { get; set; }
    }
    public class To
    {
        public byte ToProperty { get; set; }
    }
    var from = new From();
    from.FromProperty = 5;
    var to = new To();
    Swapper.Swap(from, to, f => f.FromProperty, t => t.ToProperty);
