    public abstract class C : B
    {
        //  Seal off the old getter.  From now on, its only job
        //  is to alias the new getter in the base classes.
        public sealed override int X { get { return this.XGetter; }  }
        protected abstract int XGetter { get; }
    }
