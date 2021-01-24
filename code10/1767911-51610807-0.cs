    internal class A {
        public int X { get; set; } = 1;
    }
    internal class B {
        private A myInstanceOfA = new A();
        public void test() {
            int y = myInstanceOfA.X;
        }
    }
