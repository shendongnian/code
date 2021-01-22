    using System;
    using System.Collections.Generic;
    namespace StackOverflow
    {
        /// <summary>
        /// Compiled but not run.  Copypasta at your own risk!
        /// </summary>
        public class Tester
        {
            public static void Main(string[] args)
            {
                // Contrived example #1: pushing type-specific functionality up the call stack
                var strResult = Example1.Calculate<string>("hello", s => "Could not calculate " + s);
                var intResult = Example1.Calculate<int>(1234, i => -1);
                // Contrived example #2: overriding default behavior with an alternative that's optimized for a certain type
                var ex = new Example2<int>();
                var list1A = new List<int> { 1, 2, 3 };
                var list1B = new HashSet<int> { 1, 2, 3 };
                var list2 = new HashSet<int> { 4, 5, 6 };
                ex.Concat(list1A, list2);
                ex.Concat<HashSet<int>>(list1B, list2, (l1, l2) => l1.UnionWith(l2));
            }
        }
        public class Example1
        {
            public static TParam Calculate<TParam>(TParam param, Func<TParam, TParam> errorMessage)            
            {
                bool success;
                var result = CalculateInternal<TParam>(param, out success);
                if (success)
                    return result;
                else
                    return errorMessage(param);
            }
            private static TParam CalculateInternal<TParam>(TParam param, out bool success)
            {
                throw new NotImplementedException();
            }
        }
        public class Example2<T>
        {
            public readonly Action<ICollection<T>, ICollection<T>> simpleAddRange = (l1, l2) =>
            {
                foreach (var item in l2)
                {
                    l1.Add(item);
                }
            };
            public void Concat(ICollection<T> list1, ICollection<T> list2)
            {
                Concat<ICollection<T>>(list1, list2, simpleAddRange);
            }
            public void Concat<TList>(TList list1, TList list2, Action<TList, TList> specializedAddRange)
                where TList : ICollection<T>
            {
                specializedAddRange(list1, list2);
            }
        }
    }
