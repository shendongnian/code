    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[1000];
            arr.Init(10);
            Array.ForEach(arr, Console.WriteLine);
        }
    }
    
    public static class ArrayExtensions
    {
        public static void Init<T>(this T[] array, T defaultVaue)
        {
            if (array == null)
                return;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = defaultVaue;
            }
        }
    }
