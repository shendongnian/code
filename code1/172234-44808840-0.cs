    static class Extensions
    {
        public static TSource[] CoalesceEnumerable<TSource>(this TSource[] source)
        {
            return source ?? new TSource[0];
        }
        public static bool ItemsEqual<TSource>(this TSource[] array1, TSource[] array2)
        {
            return array1.CoalesceEnumerable().Count() == array2.CoalesceEnumerable().Count()
                && !array1.CoalesceEnumerable().Except(array2.CoalesceEnumerable()).Any();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] a1 = new int[] { 1, 2, 3 };
            int[] a2 = new int[] { 3, 2, 1 };
            int[] a3 = new int[] { 1, 3 };
            int[] a4 = null;
            int[] a5 = null;
            Console.WriteLine(a1.ItemsEqual(a2)); // Output: True.
            Console.WriteLine(a2.ItemsEqual(a3)); // Output: False.
            Console.WriteLine(a4.ItemsEqual(a5)); // Output: True. No Exception.
            Console.WriteLine(a4.ItemsEqual(a3)); // Output: False. No Exception.
        }
    }
