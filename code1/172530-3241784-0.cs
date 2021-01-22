    static void Main(string[] args)
    {
        var a = Enumerable.Range(1, 3);
        var b = a.GetEnumerator();
        int x;
        while(b.MoveNext())
        {
            x = b.Current;
            Task.Factory.StartNew(() => Console.WriteLine(x));
        }
        Console.ReadLine();
    }
