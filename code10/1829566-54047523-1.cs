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
			(item)      => item.Estimated,                 //Function that gets the value to be accumulated from an element
			(item, sum) => new { Item = item, Sum = sum }  //Function that creates an element for output given the input and the accumulated sum
		);
		foreach (var item in accumulatedList)
		{
			Console.WriteLine("{0:yyyy-MM-dd} {1}", item.Item.Date, item.Sum);
		}
	}
