    abstract class Base
    {
        public abstract string Test { get; protected set; }
    
    }
    class Concrete : Base
    {
        string s;
        public override string Test
        {
            get { return s; }
            protected set { s = value; }
        }
    }
