    public void Test()
    {
    	// test data
    	List<SomeClass> list = new List<SomeClass>()
    	{
    		new SomeClass {Value = 1, Date = DateTime.Now.AddDays(-1)},
    		new SomeClass {Value = 2, Date = DateTime.Now },
    		new SomeClass {Value = 3, Date = DateTime.Now.AddDays(1)}
    	};
    	// query and update
    	(from i in list where i.Date.Day.Equals(DateTime.Now.Day) select i).First().Update(v => v.Value += 5);
    
    	foreach (SomeClass s in list) {
    		Console.WriteLine(s.Value);
    	}
    }
