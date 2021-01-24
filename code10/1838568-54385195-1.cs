    int[] a=new int[]{1,1,1,2,3,4,4};
	foreach(var item in a.GroupBy(x=>x))
	{
		Console.WriteLine($"{item.Key} {item.Count()}");
	}
