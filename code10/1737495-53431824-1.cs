    public static class ExampleFragmentation
    {
        public static void Main()
        {
            var mega = 1024 * 1024;
            var smallArrays = new int[100][];
            var largeArrays = new int[100][];
            for (int i = 0; i < 100; i++)
            {
                smallArrays[i] = CreateArray(mega);
                largeArrays[i] = CreateArray(100 * mega);
            }
            largeArrays = null;
            while (true)
            {
                DateTime start = DateTime.Now;
                long sum = 0;
                for (int i = 0; i < 100; i++)
                    foreach (var array in smallArrays)
                        foreach (var element in array)
                            sum += element;
                double time = (DateTime.Now - start).TotalSeconds;
                Console.WriteLine("sum=" + sum + "  " + time + " s");
            }
        }
        private static int[] CreateArray(int bytes)
        {
            var array = new int[bytes / sizeof(int)];
            for (int i = 0; i < array.Length; i++)
                array[i] = 1;
            return array;
        }
    }
