     OleDbConnection conn;
        OleDbCommand comm;
        OleDbDataReader dr;
        conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\db1.mdb");
        comm = new OleDbCommand("Select * from Table1 where loginId =@id and password=@pass",conn);
        comm.Parameters.Add(new OleDbParameter("@id",System.Data.oleDbType.NVarChar,20, "loginID"));
        comm.Parameters.Add(new OleDbParameter("@pass",System.Data.oleDbType.NVarChar,20, "password"));	
        conn.Open();
        dr = comm.ExecuteReader();
        conn.Close();
    if(dr.hasrows)
    {
    //login success
    }
    else
     //login fail
