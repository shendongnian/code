    public interface InterfaceC
    {
       int MethodC();
    }
    
    public class C : InterfaceA, InterfaceC
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
    
        public int MethodC()
        {
            return A * 10;
        }
    }
