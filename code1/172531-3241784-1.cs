    static void Main(string[] args)
    {
        var a = Enumerable.Range(1, 3);
        var b = a.GetEnumerator();
        while(b.MoveNext())
        {
            int x = b.Current;
            Task.Factory.StartNew(() => Console.WriteLine(x));
        }
        Console.ReadLine();
    }
