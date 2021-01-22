    class SomeObject
    {
    }
    class MyEnum : IEnumerable<SomeObject>
    {
        private List<SomeObject> _myList = new List<SomeObject>();
        public void Add(SomeObject o)
        {
            _myList.Add(o);
        }
        public IEnumerator<SomeObject> GetEnumerator()
        {
            return _myList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyEnum a = new MyEnum();
            a.Add(new SomeObject());
            foreach (SomeObject o in a)
            {
                Console.WriteLine(o.GetType().ToString());
            }
            Console.ReadLine();
        }
    }
