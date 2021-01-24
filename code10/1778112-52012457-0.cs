    List<object[]> list = new List<object[]> { new object[] { 1, 2 }, new object[] { 3, 4 } };
    foreach (object[] item in list)
    {
    	if (item.GetType().IsArray)
    	{
    		var arr = item.Cast<int>();
    		foreach (var i in arr)
    		{
    			Console.WriteLine(i);
    		}
    	}
    }
