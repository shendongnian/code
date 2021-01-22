    using System;
    public class Foo
    {
        public Bar[] Bars { get; set; }
    }
    
    public class Bar {
        public string Name { get; set; }
    }
    
    static class Program
    {
        static T[] Append<T>(this T[] arr, T value)
        {
            Array.Resize<T>(ref arr, arr == null ? 1 : (arr.Length + 1));
            arr[arr.Length - 1] = value;
            return arr;
        }
        static void Main()
        {
            Foo obj = new Foo { Bars = new[] { new Bar { Name = "abc" }, new Bar { Name = "def" } } };
            obj.Bars = obj.Bars.Append(new Bar { Name = "ghi" });
            foreach (Bar bar in obj.Bars)
            {
                Console.WriteLine(bar.Name);
            }
        }
    }
