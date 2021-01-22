    public void DoEnumerate()
    {
        foreach (var item in Enumerate())
        {
            Console.WriteLine(item);
        }
    }
    public IEnumerable<string> Enumerate()
    {
        var items = new [] { "item1", "item2" };
        foreach (var item in items) yield return item;
    }
