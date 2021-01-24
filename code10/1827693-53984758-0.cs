    public abstract class Control
    {
        public string Id { get; set; }
    }
    public abstract class ControlBuilder<TBuilder, TControl>
        where TBuilder : ControlBuilder<TBuilder, TControl>, new()
        where TControl : Control, new()
    {
        protected TControl control;
        protected ControlBuilder()
        {
            control = new TControl();
        }
        public static TBuilder With()
        {
            return new TBuilder();
        }
        public TControl Build()
        {
            control;
        }
        public TBuilder Id(string id)
        {
            control.Id = id;
            return (TBuilder)this;
        }
    }
