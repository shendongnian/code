    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication3
    {
        class ReversedEnumerator : IEnumerator<int>
        {
            List<int> v;
            int index;
    
            public ReversedEnumerator(List<int> v) {
                this.v = v;
                this.index = v.Count;
            }
    
            public int Current
            {
                get { return v[index]; }
            }
    
            public void Dispose()
            {
            }
    
            object System.Collections.IEnumerator.Current
            {
                get { return v[index]; }
            }
    
            public bool MoveNext()
            {
                return --index >= 0;
            }
    
            public void Reset()
            {
                index = this.v.Count;
            }
        }
    
        class EnumeratorStub : IEnumerable<int>
        {
            List<int> v;
    
            public EnumeratorStub(List<int> v)
            {
                this.v = v;
            }
    
            public IEnumerator<int> GetEnumerator()
            {
                return new ReversedEnumerator(v);
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return new ReversedEnumerator(v);
            }
    
        }
    
        class Program
        {
            static EnumeratorStub Reverse(List<int> v)
            {
                return new EnumeratorStub(v);
            }
    
            static void Main(string[] args)
            {
                List<int> v = new List<int>();
                v.Add(1);
                v.Add(2);
                v.Add(3);
    
                foreach (int item in Reverse(v))
                {
                    Console.WriteLine(item);
                }
    
                Console.ReadKey();
            }
        }
    }
