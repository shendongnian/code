    public class Father
    {
        public Father SomePropertyName
        {
            get {
                return SomePropertyImpl();
            }
        }
        protected virtual Father SomePropertyImpl()
        {
            // base-class version
        }
    }
    
    public class Child : Father
    {
        public new Child SomePropertyName
        {
            get
            { // since we know our local SomePropertyImpl actually returns a Child
                return (Child)SomePropertyImpl();
            }
        }
        protected override Father SomePropertyImpl()
        {
            // do something different, might return a Child
            // but typed as Father for the return
        }
    }
