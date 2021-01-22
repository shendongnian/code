    public abstract class SomethingBase
    {
        protected int value;
    
        protected SomethingBase(int value)
        {
            this.value = value;
        }
        
        public static int operator |(SomethingBase leftSide, SomethingBase rightside)
        {
            return leftSide.value | rightside.value;
        }
    }
    
    public class Something : SomethingBase
    {
        public int Value
        {
            get { return value; }
        }
    
        public Something(int value) : base(value)
        {
        }
    
        public void DoSomething()
        {
            throw new NotImplementedException();
        }
    }
