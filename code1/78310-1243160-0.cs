    //Create the OleDbConnection object 
    //and associate it with our database
    using(OleDbConnection conn = new OleDbConnection(
        "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source="+textBox1.Text)){
    
    //Open the database connection
    conn.Open();
    //Create an OleDbCommand object and
    //pass it the SQL read query and the connection to use
    OleDbCommand cmd = new OleDbCommand(sqlstr,conn);
    //Procure the OleDbDataReader object to browse the recordset 
    OleDbDataReader rdr = cmd.ExecuteReader();
    //Keep reading records in the forward direction
    while (rdr.Read())
    {
       //Use one of the various methods available to read the data
       //Eg:- GetValue, GetValues, Item etc.
    . . .
    . . .    
    }
    }
