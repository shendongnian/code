    //Now tested
    interface IEnumerableEx<T> : IEnumerable<T>
    {
        int Count { get; }
    }
    class ListWrapper<T> : List<T>, IEnumerableEx<T> 
    {
        int IEnumerableEx<T>.Count
        {
            get
            {
                return this.Count;
            }
        }
    }
    //Usage:
    class Program
    {
        static ListWrapper<int> list = new ListWrapper<int>();
        public static IEnumerableEx<int> GetList()
        {
            return (IEnumerableEx<int>)list;
        }
        static void Main(string[] args)
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            Console.WriteLine("Count:{0}", GetList().Count);
            foreach (var x in GetList())
            {
                Console.WriteLine(x);
            }
        }
    }
