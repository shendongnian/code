    using System;
    class Program {
        private static readonly Action incrementCount;
        private static readonly Func<int> getCount;
        static Program() {
            int x = 0;
            incrementCount = () => x++;
            getCount = () => x;
        }
        public void Foo() {
            incrementCount();
            incrementCount();
            Console.WriteLine(getCount());
        }
        static void Main() {
            // show it working from an instance
            new Program().Foo();
        }
    }
