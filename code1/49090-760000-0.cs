    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication3
    {
        public class ModifiableList<T> : List<T>
        {
            private readonly IList<T> pendingAdditions = new List<T>();
            private int activeEnumerators = 0;
            public ModifiableList(IEnumerable<T> collection) : base(collection)
            {
            }
            public ModifiableList()
            {
            }
            public new void Add(T t)
            {
                if(activeEnumerators == 0)
                    base.Add(t);
                else
                    pendingAdditions.Add(t);
            }
            public new IEnumerator<T> GetEnumerator()
            {
                ++activeEnumerators;
                foreach(T t in ((IList<T>)this))
                    yield return t;
                --activeEnumerators;    
                AddRange(pendingAdditions);
                pendingAdditions.Clear();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                ModifiableList<int> ints = new ModifiableList<int>(new int[] { 2, 4, 6, 8 });
                foreach(int i in ints)
                    ints.Add(i * 2);
                foreach(int i in ints)
                    Console.WriteLine(i * 2);
            }
        }
    }
