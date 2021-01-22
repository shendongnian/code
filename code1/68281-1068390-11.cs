    var e = list.GetEnumerator();
    if (e.MoveNext())
    {
        var item = e.Current;
        while (e.MoveNext())
        {
            Console.WriteLine("Looping: " + item);
            item = e.Current;
        }
        Console.WriteLine("Last one: " + item);
    }
