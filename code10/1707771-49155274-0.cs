    public class BaseWrapper
    {
        public virtual void Baz()
        {
           // Do some shared work
        }
    }
    public class BarWrapper : BaseWrapper
    {
        private Bar _instance;
        public BarWrapper(Bar instance)
        {
            _instance = instance;
        }
        public override void Baz()
        {
            base.Baz();
            // Do custom stuff for this wrapper type?
        }
    }
