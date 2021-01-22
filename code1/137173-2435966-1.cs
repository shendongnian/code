    class Program {
        static void Main(string[] args) {
            int[] a = { 0, 2, 1, 3, 4 };
            string[] z = { "Zero", "Two", "One", "Three", "Four" };
            IEnumerable<int> b = Enumerable.Swap(a, 1, 2);
            WriteAll(b);
            IEnumerable<int> c = Enumerable.MoveDown(a, 1);
            WriteAll(c);
            IEnumerable<int> d = Enumerable.MoveUp(a, 2);
            WriteAll(d);
            IEnumerable<int> f = Enumerable.MoveUp(a, 0);
            WriteAll(f);
            IEnumerable<int> g = Enumerable.MoveDown(a, 4);
            WriteAll(g);
            IEnumerable<string> h = Enumerable.Swap(z, "Two", "One");
            WriteAll(h);
            var i = z.MoveDown("Two");
            WriteAll(i);
            var j = z.MoveUp("One");
            WriteAll(j);
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }
        private static void WriteAll<T>(IEnumerable<T> b) {
            foreach (var item in b) {
                Console.WriteLine(item);
            }
        }
