    string strConn="PROVIDER=MySQLProv;SERVER=192.168.1.8;DB= test;UID=test;PWD=;PORT=;";
    OleDbConnection objConn;
    objConn=new OleDbConnection (strConn);
    objConn.Open();
    string sql="INSERT INTO MyTable (SpreadSheet) VALUES(?)";
    OleDbCommand cmd = new OleDbCommand(sql,objConn);
    OleDbParameter param = new OleDbParameter ("@image",OleDbType.Binary );
    param.Value = myData;
    cmd.Parameters.Add(param);
    cmd.ExecuteNonQuery();
    objConn.Close ();
     
