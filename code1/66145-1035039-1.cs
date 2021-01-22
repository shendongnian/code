    void Insert()
    {
    	var actual = Get();
    	using (var db = new DataClassesDataContext())
    	{
    		foreach (var set in actual.InSetsOf(5))
    		{
    			db.Shapes.InsertAllOnSubmit(set);
    			db.SubmitChanges();
    		}
    	}
    }
