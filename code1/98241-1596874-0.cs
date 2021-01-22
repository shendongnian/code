    using System;
    using System.Collections;
    using System.Collections.Generic;
    static class Program
    {
        static void Main()
        {
    
            foreach (int i in YieldDemo.SupplyIntegers())
            {
                Console.WriteLine("{0} is consumed by foreach iteration", i);
            }
        }
    }
    
     class YieldDemo
      {
         
        public static IEnumerable<int> SupplyIntegers()
         {
             return new YieldEnumerable();
           }
        class YieldEnumerable : IEnumerable<int>
        {
            public IEnumerator<int> GetEnumerator()
            {
                return new YieldIterator();
            }
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }
        class YieldIterator : IEnumerator<int>
        {
            private int state = 0;
            private int value;
            public int Current { get { return value; } }
            object IEnumerator.Current { get { return Current; } }
            void IEnumerator.Reset() { throw new NotSupportedException(); }
            void IDisposable.Dispose() { }
            public bool MoveNext()
            {
                switch (state)
                {
                    case 0: value = 1; state = 1;  return true;
                    case 1: value = 2; state = 2;  return true;
                    case 2: value = 3; state = 3; return true;
                    default: return false;
                }
            }
        }
    }
