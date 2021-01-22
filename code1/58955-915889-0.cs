    internal class Program {
        private static void Main(string[] args) {
            var bar = new Bar {A = 1, B = 2, C = 3};
            Console.WriteLine(new Foo().X(bar, it => it.A));
            Console.WriteLine(new Foo().X(bar, it => it.B));
            // or introduce a "constant" somewhere
            Func<Bar, int> cFieldSelector = it => it.C;
            Console.WriteLine(new Foo().X(bar, cFieldSelector));
        }
    }
    internal class Foo {
        // Instead of using a field by name, give it a method to select field you want.
        public int X(Bar bar, Func<Bar, int> fieldSelector) {
            return fieldSelector(bar) * 2;
        }
        public int A(Bar bar) {
            return bar.A * 2;
        }
        public int B(Bar bar) {
            return bar.B * 2;
        }
        public int C(Bar bar) {
            return bar.C * 2;
        }
    }
    internal class Bar {
        public int A;
        public int B;
        public int C;
    }
