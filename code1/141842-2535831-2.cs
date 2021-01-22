    public class C
    {
        public int Property {get;set;}
    }
    
    public class A
    {
        private C _c;
        public A(C c){_c = c;}
        
        public void ChangeC(int n) {_c.Property = n;}
    }
    
    public class B
    {
        private C _c;
        public B(C c){_c = c;}
        
        public void ChangeC(int n) {_c.Property = n;}
    }
