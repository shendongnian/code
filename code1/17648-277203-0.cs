    using System;
    using System.Collections.Generic;
    namespace ExtentionTest {
        class Program {
            static void Main(string[] args) {
                List<int> BigList = new List<int>() { 1,2,3,4,5,11,12,13,14,15};
                IEnumerable<int> Smalllist = BigList.MyMethod();
                foreach (int v in Smalllist) {
                    Console.WriteLine(v);
                }
            }
        }
        static class EnumExtentions {
            public static IEnumerable<T> MyMethod<T>(this IEnumerable<T> Container) {
                int Count = 1;
                foreach (T Element in Container) {
                    if ((Count++ % 2) == 0)
                        yield return Element;
                }
            }
        }
    }
