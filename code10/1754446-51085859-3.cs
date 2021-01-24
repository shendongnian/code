    using (var p = new ChoCSVReader("Sample6.csv"))
    {
    	p.SanitizeLine += (o, e) =>
    	{
    		string line = e.Line as string;
    		if (line != null)
    		{
    			line = line.Substring(1, line.Length - 2);
    			line = line.Replace(@"""""", @"""");
    		}
            e.Line - line;
    	};
    
    	var dt = p.AsDataTable();
        //Assign dt to DataGridView
    }
