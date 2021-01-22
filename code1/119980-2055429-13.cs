    public class TabMenuControlCollection : ControlCollection
    {
        public TabMenuControlCollection(TabMenu owner) : base(owner) { }
        public override void Add(Control child)
        {
            if (child == null)
                throw new ArgumentNullException("child");
            if (!(child is TabMenu))
                throw new ArgumentException("The TabMenu control can only have a child of type 'Tab'.");
            base.Add(child);
        }
        public override void AddAt(int index, Control child)
        {
            if (child == null)
                throw new ArgumentNullException("child");
            if (!(child is TabMenu))
                throw new ArgumentException("The TabMenu control can only have a child of type 'Tab'.");
            base.AddAt(index, child);
        }
    }
