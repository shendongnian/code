    public interface CI {
        void method(BI b);
    }
    
    public interface BI {
        int Priority { get; set; }
        int Urgency { get; set; }
    }
    
    public class A {
        B[] arr;
        CI c;
    
        public A(C c) {
            arr = new B[100];
            this.c = c;
        }
    
    
        public void method1() {
            var r = (new Random()).Next(100);
            arr[r].someMethodOfB(c);    // pass c to the method of b
        }
    
        private class B : BI {
            public int Priority { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int Urgency { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
            internal void someMethodOfB(CI aC) {
                aC.method(this);
                throw new NotImplementedException();
            }
        }
    }
    
    public class C : CI { // user implements
        public void method(BI b) {
            if (b.Priority > 10 || b.Urgency > 10)
                ; // do something with BI using b
            throw new NotImplementedException();
        }
    }
