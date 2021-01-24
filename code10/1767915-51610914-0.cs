    public class A {
        public const Int32 ConstantVariable = 0;
        // or
        public static Int32 StaticVariable = 0;
    }
    public class B {
        public void test() {
            Int32 y = A.ConstantVariable;
            // or
            Int32 y = A.StaticVariable;
        }
    }
