    using System;
    using System.Collections.Generic;
    public static class ListExt {
        public static void Sort<TSource, TValue>(
                this List<TSource> list,
                Func<TSource, TValue> selector) {
            if (list == null) throw new ArgumentNullException("list");
            if (selector == null) throw new ArgumentNullException("selector");
            var comparer = Comparer<TValue>.Default;
            list.Sort((x,y) => comparer.Compare(selector(x), selector(y)));
        }
    }
    class SomeType {
        public override string ToString() { return SomeProp; }
        public string SomeProp { get; set; }
        static void Main() {
            var list = new List<SomeType> {
                new SomeType { SomeProp = "def"},
                new SomeType { SomeProp = null},
                new SomeType { SomeProp = "abc"},
                new SomeType { SomeProp = "ghi"},
            };
            list.Sort(x => x.SomeProp);
            list.ForEach(Console.WriteLine);
        }
    }
