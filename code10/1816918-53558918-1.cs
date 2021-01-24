    static void Main(string[] args)
    {
        var items = new int[] { 3, 5, 6, 7, 8, 8, 9, 33, 34, 45, 8 };
        foreach (var item in BinarySearch(items, 8))
        {
            Console.WriteLine(item);
        }
    }
