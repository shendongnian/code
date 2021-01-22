    using System;
    using System.Collections.Generic;
    class Foo
    {
        public string Bar { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            var data = new List<Foo> {
                new Foo {Bar = "def"},
                new Foo {Bar = "ghi"},
                new Foo {Bar = "abc"},
                new Foo {Bar = "jkl"}
            };
            data.Sort(x => x.Bar);
            foreach (var item in data)
            {
                Console.WriteLine(item.Bar);
            }
        }
    
        static void Sort<TSource, TValue>(
            this List<TSource> source,
            Func<TSource, TValue> selector)
        {
            var comparer = Comparer<TValue>.Default;
            source.Sort((x,y) => comparer.Compare(selector(x), selector(y)));
        }
    
    }
