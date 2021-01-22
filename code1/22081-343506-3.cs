    interface IReadOnlyCollection<T> : IEnumerable<T>
    {
        int Count { get; }
    }
    //Now cannot be misused by downcasting to List
    // This wrapper can also be used with lists since IList inherits from ICollection
    public class CollectionWrapper<T> : IReadOnlyCollection<T>
    {
        public CollectionWrapper(ICollection<T> collection)
        {
            _collection = collection;
        }
        public int Count
        {
            get
            {
                return _collection.Count;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)_collection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)((IEnumerable)_collection).GetEnumerator();
        }
        ////////Private data///////
        ICollection<T> _collection;
    }
	
	
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            CollectionWrapper<int> collection = new CollectionWrapper<int>(list);
            Console.WriteLine("Count:{0}", collection.Count);
            foreach (var x in collection)
            {
                Console.WriteLine(x);
            }
			
            foreach (var x in (IEnumerable)collection)
            {
                Console.WriteLine(x);
            }
        }
    }
