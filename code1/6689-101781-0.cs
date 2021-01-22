    IEnumerator&lt;int&ft; enumerator = list.GetEnumerator();
    while (enumerator.MoveNext())
    {
        int i = enumerator.Current;
    
        Console.WriteLine(i);
    }
