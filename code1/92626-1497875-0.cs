    con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:/ppd/db1.mdb;Jet OLEDB:Database Password=techsoft");
    
        da = new OleDbDataAdapter("select * from contacts", con);
    
        DataSet ds = new DataSet();
    
        da.Fill(ds, "contacts");
    
        dt = ds.Tables[0];
    
        dataGridView1.DataSource = dt;
        OleDbConnection con;
    
         OleDbDataAdapter da;
    
         DataTable dt;
    
         OleDbCommand cm;  
    
        string insertQuery = @"insert into  contacts([names],[number]) Values (@names,@number)";
    
        cm = new OleDbCommand(insertQuery, con);
    
        cm.Parameters.Add("@names", OleDbType.VarChar, 10, "names");
    
        cm.Parameters.Add("@number", OleDbType.VarChar, 10, "number");
    
             
        da.InsertCommand = cm;
