using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApplication3
{
    class FakeIterator
    {
        int _count;
        public FakeIterator(int count)
        {
            _count = count;
        }
        public string Current { get { return "Hello World!"; } }
        public bool MoveNext()
        {
            if(_count-- > 0)
                return true;
            return false;
        }
    }
    class FakeCollection
    {
        public FakeIterator GetEnumerator() { return new FakeIterator(3); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string value in new FakeCollection())
                Console.WriteLine(value);
        }
    }
}
