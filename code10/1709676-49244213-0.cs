	var allObjects = new List<Foo>
	{
		new Foo { MyDate = "3/10/18" },
		new Foo { MyDate = "3/11/18" },
		new Foo { MyDate = "3/12/18" },
		new Foo { MyDate = "3/13/18" },
		new Foo { MyDate = "3/14/18" }
	};
	var valuesToRemove = new DayOfWeek[]
	{ 
		DayOfWeek.Saturday, DayOfWeek.Sunday 
	};
	var list = allObjects.Where   //<-- This is the part that will interest you
	( 
		x => Array.IndexOf
		(
			valuesToRemove, 
			Convert.ToDateTime(x.MyDate).DayOfWeek
		) == -1
	);
	Console.WriteLine(string.Join("\r\n", list));
