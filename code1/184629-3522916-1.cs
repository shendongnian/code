    abstract class MustImpliment
    {
        protected MustImpliment()
        {
            object[] attributes = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attributes == null || attributes.Length == 0)
                throw new NotImplementedException("Pick a better exception");
        }
        // Must impliment DescriptionAttribute
        public abstract void DoSomething();
    }
    class DidntImpliment : MustImpliment
    {
        public override void DoSomething()
        {
            // ...
        }
    }
