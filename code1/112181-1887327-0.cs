    public class MyCategory
    {
        private readonly MyType type;
        public MyCategory()
        {
            this.type = new MyType();
        }
        public MyType Type
        {
            get { return this.type; }
        }
        // etc.
        public override string ToString()
        {
            return "My Category";
        }
    }
    public class MyType
    {
        public override string ToString()
        {
            return "My Type";
        }
        // more properties here...
    }
