    //Create the data set and table
    DataSet ds = new DataSet("New_DataSet");
    DataTable dt = new DataTable("New_DataTable");
    //Set the locale for each
    ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
    dt.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
    //Open a DB connection (in this example with OleDB)
    OleDbConnection con = new OleDbConnection(dbConnectionString);
    con.Open();
    //Create a query and fill the data table with the data from the DB
    string sql = "SELECT Whatever FROM MyDBTable;";
    OleDbCommand cmd = new OleDbCommand(sql, con);
    OleDbDataAdapter adptr = new OleDbDataAdapter();
    
    adptr.SelectCommand = cmd;
    adptr.Fill(dt);
    con.Close();
    //Add the table to the data set
    ds.Tables.Add(dt);
    //Here's the easy part. Create the Excel worksheet from the data set
    ExcelLibrary.DataSetHelper.CreateWorkbook("MyExcelFile.xls", ds);
