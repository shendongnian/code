    abstract public class BaseClass
    {
        abstract public double MyPop { get; protected set; }
    }
    public class DClass : BaseClass
    {
        private double _myProp;
        public override double MyProp
        {
            get { return _myProp; }
            protected set { _myProp = value; }
        }
    }
