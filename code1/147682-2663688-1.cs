    interface IControl
    {
        string Id { get; set; }
        object Value { get; set; }
    }
    class Label : IControl
    {
        public string Id { get; set; }
        public string Value { get; set; }
        object IControl.Value
        {
            get { return this.Value; }
            set { this.Value = (string)value; }
        }
    }
    class Repeater : IControl
    {
        public string Id { get; set; }
        public IList<IControl> Value { get; set; }
        object IControl.Value
        {
            get { return this.Value; }
            set { this.Value = (IList<IControl>)value; }
        }
    }
