    using System.Data.OleDb;
    string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filepath + ";" + "Extended Properties="+(char)34+"Excel 8.0;IMEX=1;"+(char)34;
    string CommandText = "select * from [Sheet1$]";
    OleDbConnection myConnection = new OleDbConnection(ConnectionString);
    myConnection.Open();
    OleDbDataAdapter myAdapter = new OleDbDataAdapter(CommandText, myConnection);
    ds = null;
    ds = new DataSet();
    myAdapter.Fill(ds);
