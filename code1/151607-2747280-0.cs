    public class Parent
    {
        public Parent()
        {
            Initialize();
        }
    
        protected virtual void Initialize()
        {
            // do stuff
        }
    }
    
    public class Child : Parent
    {
        protected override void Initialize()
        {
            // do child stuff
            base.Initialize();
        }
    }
