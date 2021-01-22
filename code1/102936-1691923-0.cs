    OleDbConnection oConn = new OleDbConnection("Provider=VFPOLEDB.1;Data Source=C:\\SomePath");
    OleDbCommand oCmd = new OleDbCommand();
    oCmd.Connection = oConn;
    oCmd.Connection.Open();
    oCmd.CommandText = "select * from SomeTable where someCondition into table YourNewTable";
    oCmd.ExecuteNonQuery();         
    oConn.Close();
