    string connectionString = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=test.xls;";
    connectionString += "Extended Properties=Excel 8.0;";
    OleDbConnection con = new OleDbConnection(connectionString);
    
    DataSet ds = new DataSet("stuff");
    
    OleDbDataAdapter adapter = new OleDbDataAdapter();
    // adapter.SelectCommand = new OleDbCommand("Select * from [Sheet1$A1:A100];", con);
    // adapter.SelectCommand = new OleDbCommand("Select * from [Sheet1$];", con);
    adapter.SelectCommand = new OleDbCommand("Select * from [Sheet1$] where [A] = 'John';", con);
    adapter.Fill(ds);
    
    foreach (DataRow dr in ds.Tables[0].Rows)
    {
        foreach (DataColumn dc in ds.Tables[0].Columns)
        {
            Console.WriteLine(dr[dc].ToString());
        }
    }
