    class Program
    {
        static SomeCollection _sc = new SomeCollection();
        static void Main(string[] args)
        {
            // Create one thread that adds entries and
            // one thread that reads them
            Thread t1 = new Thread(AddEntries);
            Thread t2 = new Thread(EnumEntries);
            t2.Start(_sc);
            t1.Start(_sc);
        }
        static void AddEntries(object state)
        {
            SomeCollection sc = (SomeCollection)state;
            for (int x = 0; x < 20; x++)
            {
                Trace.WriteLine("adding");
                sc.Add(x);
                Trace.WriteLine("added");
                Thread.Sleep(x * 3);
            }
        }
        static void EnumEntries(object state)
        {
            SomeCollection sc = (SomeCollection)state;
            for (int x = 0; x < 10; x++)
            {
                Trace.WriteLine("Loop" + x);
                foreach (int item in sc.AllValues)
                {
                    Trace.Write(item + " ");
                }
                Thread.Sleep(30);
                Trace.WriteLine("");
            }
        }
    }
    class SomeCollection
    {
        private List<int> _collection = new List<int>();
        private object _sync = new object();
        public void Add(int i)
        {
            lock(_sync)
            {
                _collection.Add(i);
            }
        }
        public IEnumerable<int> AllValues
        {
            get
            {
                lock (_sync)
                {
                    foreach (int i in _collection)
                    {
                        yield return i;
                    }
                }
            }
        }
    }
