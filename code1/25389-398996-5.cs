    using System;
    class Foo {
        public int Current { get; private set; }
        private int step;
        public bool MoveNext() {
            if (step >= 5) return false;
            Current = step++;
            return true;
        }
    }
    class Bar {
        public Foo GetEnumerator() { return new Foo(); }
    }
    static class Program {
        static void Main() {
            Bar bar = new Bar();
            foreach (int item in bar) {
                Console.WriteLine(item);
            }
        }
    }
