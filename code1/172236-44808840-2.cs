    class Program
    {
        static void Main(string[] args)
        {
            int[] a1 = new int[] { 1, 2, 3 };
            int[] a2 = new int[] { 3, 2, 1 };
            int[] a3 = new int[] { 1, 3 };
            int[] a4 = null;
            int[] a5 = null;
            int[] a6 = new int[0];
            Console.WriteLine(a1.ItemsEqual(a2)); // Output: True.
            Console.WriteLine(a2.ItemsEqual(a3)); // Output: False.
            Console.WriteLine(a4.ItemsEqual(a5)); // Output: True. No Exception.
            Console.WriteLine(a4.ItemsEqual(a3)); // Output: False. No Exception.
            Console.WriteLine(a5.ItemsEqual(a6)); // Output: False. No Exception.
        }
    }
