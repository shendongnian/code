    public void Enumerate()
    {
        foreach (var item in EnumerateItems())
        {
            Console.WriteLine(item);
        }
    }
    public IEnumerable<string> EnumerateItems()
    {
        yield return "item1";
        yield return "item2";
        yield break;
    }
