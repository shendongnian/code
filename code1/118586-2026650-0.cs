    public abstract class BaseClass
    {
        public abstract double MyPop { get; }
    }
    
    public class DClass: BaseClass
    {
        private double _myPop = 0;
        public override double MyPop 
        {
            get { return _myPop; }
        }
        // some other methods here that use the _myPop field
    }
