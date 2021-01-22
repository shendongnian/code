    namespace A {
        public class B {
            protected class C { }
        }
        public class D {
            void E() {
                var F = new A.B();    // ok!
                var G = new A.B.C();  // error!
            }
        }
    }
