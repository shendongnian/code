    class Program {
        static void Main(string[] args) {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            ReadOnlyCollection<int> collection = new ReadOnlyCollection<int>(list);
            Console.WriteLine("Count:{0}", collection.Count);
            foreach (var x in collection) {
                Console.WriteLine(x);
            }
            foreach (var x in (IEnumerable)collection) {
                Console.WriteLine(x);
            }
        }
    }
