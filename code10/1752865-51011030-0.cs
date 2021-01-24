    using System;
    
    namespace CTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test t = new Test();
                var tuple = typeof(Test).GetMethod(nameof(t.ReturnTuple)).Invoke(t, null);
                int[] i = (int[])typeof((int[], string[])).GetField("Item1").GetValue(tuple);
                string[] s = (string[])typeof((int[], string[])).GetField("Item2").GetValue(tuple);
    
                foreach (int data in i)
                {
                    Console.WriteLine(data.ToString());
                }
                foreach (string data in s)
                {
                    Console.WriteLine(data);
                }
    
                // Output :
                // 1
                // 2
                // 3
                // a
                // b
                // c
            }
        }
    
        class Test
        {
            public (int[], string[]) ReturnTuple() => (new int[] { 1, 2, 3 }, new string[] { "a", "b", "c" });
        }
    }
