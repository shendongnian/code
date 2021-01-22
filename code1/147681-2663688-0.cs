    interface IControl
    {
        string Id { get; set; }
    }
    interface IValueControl : IControl
    {
        object Value { get; set; }
    }
    interface IItemsControl : IControl
    {
        public IList<IControl> Values { get; set; }
    }
    class Label : IValueControl
    {
        public string Id { get; set; }
        public object Value { get; set; }
    }
    class Repeater : IItemsControl
    {
        public string Id { get; set; }
        public IList<IControl> Values { get; set; }
    }
