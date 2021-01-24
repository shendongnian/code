    dynamic d = ...; // Whatever value you're interested in
    ShowList(d);
    private void ShowList<T>(IEnumerable<T> list)
    {
        Console.WriteLine($"Implements IEnumerable<{typeof(T)}>");
    }
    private void ShowList(object backstop)
    {
        Console.WriteLine("I guess it doesn't implement IEnumerable<T> at all");
    }
