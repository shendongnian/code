    static void Main()
    {
        int[] a = new int[] {1, 2, 45, 4, 5, 6, 7};
        int[] b = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            int bIndex = b.Length - i - 1;
            b[bIndex] = a[i];
            Console.WriteLine(b[bIndex]);
        }
        Console.ReadLine();
    }
