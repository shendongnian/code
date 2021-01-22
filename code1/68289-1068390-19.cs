    // i'm assuming the non-generic IEnumerable in this code
    // wrap the enumerator in a "using" block if dealing with IEnumerable<T>
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
