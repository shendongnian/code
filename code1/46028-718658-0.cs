    class Program
    {
        static void Main(string[] args)
        {
            int Result = DerivedClass.Instance.DoubleNumber();
            Console.WriteLine(Result.ToString());   // Returns 0
        }
    }
    
    class BaseClass
    {
        protected BaseClass(){} // this enforces that it can not be created
    
        public int MyNumber;
    
        public virtual int DoubleNumber()
        {
            return (MyNumber*2);
        }
    }
    
    public class DerivedClass : BaseClass
    {
        // this also ensures that it can not be created outside
        protected DerivedClass(){
            MyNumber = 5;
        }
        
        // only way to access this is by Instance member...
        public static DerivedClass Instance = new DerivedClass();
    }
