    public interface MyExtendedInterfaceA : InterfaceA
    {
        int B {get;set}
    }
    
    public class B : MyExtendedInterfaceA
    {
        private InterfaceA _implementsA = new A();
        
        public int A
        {
            get
            {
                return _implementsA.A;
            }
            set
            {
                _implementsA.A = value;
            }
        }
    
        public int B {get; set;}
    }
