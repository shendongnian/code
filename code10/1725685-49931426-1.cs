    public interface IC {
        void method(IB b);
    }
    
    public interface IB {
        int Priority { get; set; }
        int Urgency { get; set; }
    }
    
    public class A {
        B[] arr;
        IC c;
    
        public A(C c) {
            arr = new B[100];
            this.c = c;
        }
    
    
        public void method1() {
            var r = (new Random()).Next(100);
            arr[r].someMethodOfB(c);    // pass c to the method of b
        }
    
        private class B : IB {
            public int Priority { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public int Urgency { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
            internal void someMethodOfB(IC aC) {
                aC.method(this);
                throw new NotImplementedException();
            }
        }
    }
    
    public class C : IC { // user implements
        public void method(IB b) {
            if (b.Priority > 10 || b.Urgency > 10)
                ; // do something with BI using b
            throw new NotImplementedException();
        }
    }
