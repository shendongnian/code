    public class BaseClass
    {
        public int A { get; set; }
        public int B { get; set; }
        private T ConvertTo<T>() where T : BaseClass, new()
        {
             return new T
             {
                 A = A,
                 B = B
             }
        }
        public DerivedClass1 ConvertToDerivedClass1()
        {
             return ConvertTo<DerivedClass1>();
        }
        public DerivedClass2 ConvertToDerivedClass2()
        {
             return ConvertTo<DerivedClass2>();
        }
    }
    
    public class DerivedClass1 : BaseClass
    {
        public int C { get; set; }
    }
    
    public class DerivedClass2 : BaseClass
    {
        public int D { get; set; }
    }
