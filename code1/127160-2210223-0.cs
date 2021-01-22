    public class ProtectedConstructor
    {
        protected ProtectedConstructor(string arg)
        {
            // do something with arg
        }
        public static ProtectedConstructor GetInstance()
        {
            return new ProtectedConstructor("test"); 
        }
    } 
    public class DerivedClass : ProtectedConstructor
    {
        protected DerivedClass(string arg) : base(arg)
        {
        }
    
        public void createInstance()
        {
            DerivedClass p = new DerivedClass("test"); 
        }
        public static DerivedClass getInstance()
        {
            return new DerivedClass("test"); 
        }
    }
