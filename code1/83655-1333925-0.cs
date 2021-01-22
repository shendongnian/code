    public class A
    {
        protected A ()
        {
            Initialize();
        }
    
        protected virtual Initialize()
        {
        }
    }
    
    public class B : A
    {
        public B ()
            : base()
        {
        }
    
        protected override Initialize()
        {
            // do something here
    
            base.Initialize();
        }
    }
