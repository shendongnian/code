    public class BaseClass
    {
        public BaseClass (string param1)
        {
             Param1 = param1;
        }
        public string SomeProp1 { get; set; }
        public string Param1 { get; private set; }
    }
    
    public class DerivedClass : BaseClass
    {
        public DerivedClass (string param1) : base(param1){}
        public string SomeProp2 { get; set; }
    }
