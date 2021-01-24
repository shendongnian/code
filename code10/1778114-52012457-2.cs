    foreach (List<object> item in list)
    {
  		int[] arr = item.Cast<int>().ToArray();
   		foreach (var i in arr)
   		{
   			Console.WriteLine(i);
   		}
   	}
