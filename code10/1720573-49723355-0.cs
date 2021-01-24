    Enum Location { Big, Large, Small, Drawer, Hanging}
    class Tool
    {
        public abstract Location Location { get; }
    }
    class Hammer
    {
        public override Location { get { return Location.Top; } }
    }
