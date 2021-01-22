    using System;
    using System.Collections.Generic;
    using System.Linq;
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
                var list1 = new List<int> { 1, 2, 3 };
                var list2 = new int[] { 4, 5, 6 };
                Example2<int>.DoSomething(list1, list2);
                var list1H = new HashSet<int> { 1, 2, 3 };
                Example2<int>.DoSomething<HashSet<int>>(list1H, list2, (l1, l2) => l1.UnionWith(l2));
            }
        }
        public static class Example1
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
        public static class Example2<T>
        {
            public static void DoSomething(ICollection<T> list1, IEnumerable<T> list2)
            {
                Action<ICollection<T>, IEnumerable<T>> genericUnion = (l1, l2) =>
                {
                    foreach (var item in l2)
                    {
                        l1.Add(item);
                    }
                    l1 = l1.Distinct().ToList();
                };
                DoSomething<ICollection<T>>(list1, list2, genericUnion);
            }
            public static void DoSomething<TList>(TList list1, IEnumerable<T> list2, Action<TList, IEnumerable<T>> specializedUnion)
                where TList : ICollection<T>
            {
                /* stuff happens */
                specializedUnion(list1, list2);
                /* other stuff happens */            
            }
        }
    }
