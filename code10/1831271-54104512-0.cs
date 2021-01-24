	public Model[] ListDaftarPjsp()
	{
		var query = from x in db.PJSPEvaluation
					select new Model
					{
						foo = x.Foo,
						bar = x.Bar               
					};
		var list = query.ToArray();
	    foreach (Model item in list) 
		{
	        item.condition = "example";
	    }
	    return list;
	}
