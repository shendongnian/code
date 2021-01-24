    namespace MainClass
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] array = { 3, 5, 15, 22, 12, 15, 23 };
    
                int[] x = MergeSort(array);
    
                foreach (int i in x)
                {
                    Console.WriteLine(i);
                }
    
                Console.ReadKey();
            }
        public static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            (int[], int[]) p = SplitArray(array);
            int[] left = MergeSort(p.Item1);
            int[] right = MergeSort(p.Item2);
            return Merge(left, right);
        }
        public static int[] Merge(int[] low, int[] high)
        {
            int[] middle = new int[(low.Length + high.Length)];
            int count = 0;
            foreach (int item in low)
            {
                Console.WriteLine("low: " + item + ',');
            }
            foreach (int item in high)
            {
                Console.WriteLine("high: " + item + ',');
            }
            int low_index = 0;
            int high_index = 0;
            while (low_index < low.Length && high_index < high.Length)
            {
                if (low[low_index] < high[high_index])
                {
                    middle.SetValue(low[low_index], count);
                    low_index++;
                    count++;
                    Console.WriteLine("Low inserted.");
                }
                else
                {
                    middle.SetValue(high[high_index], count);
                    high_index++;
                    count++;
                    Console.WriteLine("High inserted.");
                }
            }
            while (high_index < high.Length)
            {
                middle[low_index + high_index] = high[high_index++];
            }
            while (low_index < low.Length)
            {
                middle[low_index + high_index] = low[low_index++];
            }
            return middle;
        }
        public static (int[], int[]) SplitArray(int[] k)
        {
            int[] a = new int[((k.Length + 1) / 2)];
            int[] b = new int[(k.Length / 2)];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = k[i];
            }
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = k[i + a.Length];
            }
            return (a, b);
        }
    }
