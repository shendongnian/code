    public class A
    {
        protected A()
        {
            // Do pre-initialization here still.
            Initialize();
        }
    
        protected virtual Initialize()
        {
            // Do all post-derived-class initialization here.
        }
    }
    
    public class B : A
    {
        public B()
            : base()
        {
        }
    
        protected override Initialize()
        {
            // Do initialization between pre- and post- initialization here.
    
            base.Initialize();
        }
    }
