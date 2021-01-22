    public class Base
    {
        public Base() : this(true) { }
         
        protected Base(bool runInitializer)
        {
            if (runInitializer)
            {
                this.Initialize(runInitializer);
            }
        }
         
        protected void Initialize()
        {
            ...initialize...
        }
    }
    public class Derived : Base
    {
        // explicitly referencing the base constructor keeps
        // the default one from being invoked.
        public Derived() : Base(false)
        {
           ...derived code
           this.Initalize();
        }
    }
