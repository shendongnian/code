    static void @for<T>(IEnumerable<T> input)
    {
        T item;
        using (var e = input.GetEnumerator())
            for (; e.MoveNext(); )
            {
                item = e.Current;
                Console.WriteLine(item);
            }
    }
    static void @foreach<T>(IEnumerable<T> input)
    {
        foreach (var item in input)
            Console.WriteLine(item);
    }
    static void @while<T>(IEnumerable<T> input)
    {
        T item;
        using (var e = input.GetEnumerator())
            while (e.MoveNext())
            {
                item = e.Current;
                Console.WriteLine(item);
            }
    }
    static void @goto<T>(IEnumerable<T> input)
    {
        T item;
        using (var e = input.GetEnumerator())
        {
            goto check;
        top:
            item = e.Current;
            Console.WriteLine(item);
        check:
            if (e.MoveNext())
                goto top;
        }
    }
    static void @gotoTry<T>(IEnumerable<T> input)
    {
        T item;
        var e = input.GetEnumerator();
        try
        {
            goto check;
        top:
            item = e.Current;
            Console.WriteLine(item);
        check:
            if (e.MoveNext())
                goto top;
        }
        finally
        {
            if (e != null)
                e.Dispose();
        }
    }
