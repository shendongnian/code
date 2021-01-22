    using System;
    using System.Collections.Generic;
    
    namespace Tester
    {
        class Program
        {
            private interface I
            {
                string GetValue();
            }
    
            private class A : I
            {
                private string value;
    
                public A(string v)
                {
                    value = v;
                }
    
                public string GetValue()
                {
                    return value;
                }
            }
    
            static void Main(string[] args)
            {
                List<I> theIList = new List<I>();
    
                foreach (A[] a in GetAList())
                {
                    theIList.AddRange((I[])a);
                }
    
                foreach (I i in theIList)
                {
                    Console.WriteLine(i.GetValue());
                }
            }
    
            private static IEnumerable<A[]> GetAList()
            {
                yield return new [] { new A("1"), new A("2"), new A("3") };
                yield return new [] { new A("4") };
            }
        }
    }
