    string csv = @"Id, Name, City
    	1, Tom, NY
    	2, Mark, NJ
    	3, Lou, FL
    	4, Smith, PA
    	5, Raj, DC";
    
    StringBuilder sb = new StringBuilder();
    using (var p = ChoCSVReader.LoadText(csv).WithFirstLineHeader()
    	.WithField("Id")
    	.WithField("Name")
    	)
    {
    	using (var w = new ChoXmlWriter(sb)
    		.Configure(c => c.RootName = "Emps")
    		.Configure(c => c.NodeName = "Emp")
    		)
    	{
    		w.Write(p);
    	}
    }
    
    Console.WriteLine(sb.ToString());
