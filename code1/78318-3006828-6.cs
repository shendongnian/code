    public static System.Data.DataTable GetSchemaData(string file)
    {
    	System.Data.DataTable columns;
    	using(System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file))
    	{
    		connection.Open();
    		columns = connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Columns,new object[]{null,null,null,null});
    	}
    	return columns;
    }
