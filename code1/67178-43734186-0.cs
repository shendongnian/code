    public abstract class DynamicBaseClass
    {
        public static dynamic Get (int id) { throw new NotImplementedException(); }
    }
    public abstract class BaseClass : DynamicBaseClass
    {
        public static new BaseClass Get (int id) { return new BaseClass(id); }
    }
    public abstract class DefinitiveClass : BaseClass
    {
        public static new DefinitiveClass Get (int id) { return new DefinitiveClass(id);
    }
    
    public class Test
    {
        public static void Main()
        {
            var testBase = BaseClass.Get(5);
            // No cast required, IntelliSense will even tell you
            // that var is of type DefinitiveClass
            var testDefinitive = DefinitiveClass.Get(10);
        }
    }
            
