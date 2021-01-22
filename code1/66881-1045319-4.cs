using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Enumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCache&lt;string> cache = new MyCache&lt;string>();
            cache.Add("test");
            foreach (string item in cache)
                Console.WriteLine(item);
            Console.ReadLine();
        }
    }
    public class MyCache&lt;T>: System.Collections.IEnumerable
    {
        private  readonly LinkedList&lt;T> InternalCache = new LinkedList&lt;T>();
        private  readonly object _Lock = new Object();
        public  void Add(T item)
        {
            lock (_Lock)
            {
                if (InternalCache.Count == 10)
                    InternalCache.RemoveLast();
                InternalCache.AddFirst(item);
            }
        }
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // copy the internal cache to an array.  We'll really be enumerating that array
            // our enumeration won't block subsequent calls to Add, but this "foreach" instance won't see Adds either
            lock (_Lock)
            {
                T[] enumeration = new T[InternalCache.Count];
                InternalCache.CopyTo(enumeration, 0);
                return enumeration.GetEnumerator();
            }
        }
        #endregion
    }
}
