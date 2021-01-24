    static void Main()
    {                         //  0  1  2  3  4  5  6  7  8  9
        var ints = new List<int> {0, 1, 0, 3, 4, 5, 0, 0, 8, 9};
        var result = ints.PartitionBy(((item, index) => item == index)); // Items where value == index.
        foreach (var seq in result)
            Console.WriteLine(string.Join(", ", seq));
        // Output is:
        // 0, 1
        // 3, 4, 5
        // 8, 9
    }
