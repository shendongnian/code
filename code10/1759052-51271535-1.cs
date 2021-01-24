    static void Main(string[] args) {
        var arr = new int[421];
        var parts = Partition(arr, 1);
        for (int ix = 0; ix < parts.Length-1; ++ix) {
            Console.WriteLine("{0,3}..{1,-3}", parts[ix], parts[ix + 1]);
        }
        Console.ReadLine();
    }
