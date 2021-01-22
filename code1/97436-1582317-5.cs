    var list = new List<int>(Enumerable.Range(1, 10));
    for (int i = list.Count - 1; i >= 0; i--)
    {
    	if (list[i] > 5)
    		list.RemoveAt(i);
    }
    list.ForEach(i => Console.WriteLine(i));
