    public abstract class Base
    {
        public string StaticProperty { get; }
        protected Base(string staticProperty)
        {
            StaticProperty = staticProperty ?? throw new ArgumentNullException(nameof(staticProperty));
        }
    }
