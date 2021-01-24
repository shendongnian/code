    static void Main(string[] args)
    {
        var array = new bool[] { false, false, false, false, false, false };
        var length = array.Length;
        for (int i = 0; i < length; i++)
        {
            for (int j = i + 1; j < length; j++)
            {
                var arr = (bool[])array.Clone();
                arr[i] = arr[j] = true;
                arr.ToList().ForEach(s => Console.Write((s ? 1 : 0) + " "));
                Console.WriteLine();
            }
        }
        Console.Read();
    }
