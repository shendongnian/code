    public abstract class Base
    {
        public virtual int Property
        {
            get { return this.GetProperty(); }
            set { }
        }
    
        protected abstract int GetProperty();
    }
