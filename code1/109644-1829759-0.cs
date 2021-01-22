    public class Base
    {
        public virtual decimal MathValue { get; set; }
    }
    
    public class Derived : Base
    {
        public override decimal MathValue
        {
            get { return Math.Round(base.MathValue); }
        }
    }
