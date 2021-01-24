	public static void Main()
	{
		var list = new List<Foo>
		{
			new Foo { Date = new DateTime(2018,1,1), Estimated = 1 },
			new Foo { Date = new DateTime(2018,1,2), Estimated = 2 },
			new Foo { Date = new DateTime(2018,1,3), Estimated = 3 },
			new Foo { Date = new DateTime(2018,1,4), Estimated = 4 },
			new Foo { Date = new DateTime(2018,1,5), Estimated = 5 }
		};
		var accumulatedList = list.Accumulate
		( 
			(item)      => item.Estimated,                    //Given an item, get the value to be summed
			(item, sum) => new { Item = item, Sum = sum }     //Given an item and the sum, create an output element
		);
		foreach (var item in accumulatedList)
		{
			Console.WriteLine("{0:yyyy-MM-dd} {1}", item.Item.Date, item.Sum);
		}
	}
