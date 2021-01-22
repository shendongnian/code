    class C {
    
        public static readonly C Instance = new C();
        private C() {
        }
    
    }
    
    B b = new B(C.Instance);
    A a = new A(C.Instance);
