    abstract class Father
    {
        abstract public int MyInt { get; }
    }
    
    class Son : Father
    {
        public override int MyInt
        {
            get { return 1; }
        }
    }
