    static void Main(string[] args)
    {
        double[] test = new double[3]
                            {
                                0, 12, 14.12
                            };
        List<int> ilist = new List<int>() { 3,5,1 };
        byte[] doubles = test.GetBytes(BitConverter.GetBytes);
        byte[] ints = ilist.GetBytes(BitConverter.GetBytes);
        Console.WriteLine("Double collection as bytes:");
        foreach (var d in doubles)
        {
            Console.WriteLine(d);
        }
        Console.WriteLine("Int collection as bytes:");
        foreach (var i in ints)
        {
            Console.WriteLine(i);
        }           
        Console.ReadKey();
    }
