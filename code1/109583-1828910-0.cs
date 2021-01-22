    using System.Collections;
    using System.Collections.Generic;
    using System;
    class MyTuple
    {
        public int Value {get;private set;}
        public int Index { get; private set; }
        public int RunningTotal { get; private set; }
        public MyTuple(int value, int index, int runningTotal)
        {
            Value = value; Index = index; RunningTotal = runningTotal;
        }
        static IEnumerable<MyTuple> SomeMethod(IEnumerable<int> data)
        {
            int index = 0, total = 0;
            foreach (int value in data)
            {
                yield return new MyTuple(value, index++,
                    total = total + value);
            }
        }
        static void Main()
        {
            int[] data = { 1, 2, 3 };
            foreach (var tuple in SomeMethod(data))
            {
                Console.WriteLine("{0}: {1} ; {2}", tuple.Index,
                    tuple.Value, tuple.RunningTotal);
            }
        }
    }
