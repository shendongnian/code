    static void Main()
    {
        int[] a = new int[] {1, 2, 45, 4, 5, 6, 7};
        int[] b = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            b[b.Length - i - 1] = a[i];
        }
        Console.WriteLine($"'a' array: {string.Join(",", a)}");
        Console.WriteLine($"'b' array: {string.Join(",", b)}");
        Console.ReadLine();
    }
