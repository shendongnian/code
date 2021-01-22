    public static IEnumerable<int> GetItems( Action<int> setter, Func<int> getter )
    {
        setter(42);
        yield return 7;
    }
	
    //...
    int local = 0;
    IEnumerable<int> items = GetItems((x)=>{local = x;}, ()=>local);
    Console.WriteLine(local); // 0
    items.GetEnumerator().MoveNext();
    Console.WriteLine(local); // 42
