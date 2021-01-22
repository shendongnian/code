    static int Sum(int[] a, int index = 0)
    {
        if (a[index] == a[a.Length - 1])
        {
            return a[a.Length - 1];
        }
        return a[index] + Sum(a, index + 1);
    }
    static void Main()
    {
        int[] arr = {1, 2, 3, 9, 15};
        Console.WriteLine(Sum(arr));
    }
