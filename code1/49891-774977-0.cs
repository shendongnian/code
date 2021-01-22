    internal struct Tuple<T> {
        public T A;
        public T B;
    }
    internal class Program {
        private static void Main(string[] args) {
            var ints = new[] { 5, 7, 11, 13 };
            IEnumerable<Tuple<int>> result = ints.Aggregate<int, IEnumerable<Tuple<int>>>(new List<Tuple<int>>(),
                    (sum, item) => sum.Concat(new[] { new Tuple<int> { A = sum.LastOrDefault().A + item, B = item } }));
            Console.WriteLine(string.Join(" ", result.Select(item => "(" + item.A + "," + item.B + ")").ToArray()));
        }
    }
