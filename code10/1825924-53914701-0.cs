    static void Main(string[] args)
    {
    	var dtToXl = new DtToExcel();
    	var dt = new DataTable();
    	dt.Columns.Add("Col1");
    	dt.Columns.Add("Col2");
    	dt.Columns.Add("Col3");
    	dt.Rows.Add("R1C1", "R1C2", "R1C3");
    	dt.Rows.Add("R2C1", "R2C2", "R2C3");
    
    	dtToXl.GetExcel(dt);
    	if(Debugger.IsAttached)
    	{
    		Console.ReadLine();
    	}
    }
