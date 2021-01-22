        var arraylist = new ArrayList();
        var arrayListSyncronized = ArrayList.Synchronized(arraylist
        Console.WriteLine($"syncronized {arraylist.IsSynchronized}");
        Console.WriteLine($"syncronized {arrayListSyncronized.IsSynchronized}");
		var list = new List<object>();
		var listSyncronized = ArrayList.Synchronized(list);
		Console.WriteLine($"syncronized {list.IsSynchronized}");//error, no such prop
		Console.WriteLine($"syncronized {list.IsSynchronized}");//error, no such prop
