    static void @for<T>(T[] input)
    {
        T item;
        T[] copy = input;
        for (int i = 0; i < copy.Length; i++)
        {
            item = copy[i];
            Console.WriteLine(item);
        }
    }
    static void @foreach<T>(T[] input)
    {
        foreach (var item in input)
            Console.WriteLine(item);
    }
    static void @while<T>(T[] input)
    {
        T item;
        T[] copy = input;
        int i = 0;
        while (i < copy.Length)
        {
            item = copy[i];
            Console.WriteLine(item);
            i++;
        }
    }
    static void @goto<T>(T[] input)
    {
        T item;
        T[] copy = input;
        int i = 0;
        goto check;
    top:
        item = copy[i];
        Console.WriteLine(item);
        i++;
    check:
        if (i < copy.Length)
            goto top;
    }
