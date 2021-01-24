    private void OnRun(object sender, EventArgs e)
    {
    	using (var db = new StackOverflowContext())
    	{
    		var t3 = db.Table3;
    		foreach (Table3 t in t3)
    		{
                // Explicit loading
    			db.Entry(t).Reference(p => p.Table1).Load();
                // Get Table1Id through navigation property
    			int id = t.Table1.Table1Id;
    		}
    	}
    }
