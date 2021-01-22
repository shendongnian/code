    public IEnumerable<int> EvenNumbers0To10()
    {
        for (int i=0; i <= 10; i += 2)
        {
            yield return i;
        }
    }
    // Later
    foreach (int x in EvenNumbers0To10())
    {
        Console.WriteLine(x); // 0, 2, 4, 6, 8, 10
    }
