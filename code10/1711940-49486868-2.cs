    string connectionString = "Provider=OvHOleDbProv.OvHOleDbProv.1;Persist Security Info=True;User ID=user;Password=password;Data Source=192.168.7.96;Location=\"\";Mode=ReadWrite;Extended Properties=\"\";";
    OleDbConnection connection = new OleDbConnection(connectionString);
    connection.Open();
    OleDbCommand command = new OleDbCommand() { Connection = connection, CommandText = "select TABLE_NAME from SYSTABLES where TABLE_TYPE='TABLE'" };
    OleDbDataReader datareader = command.ExecuteReader();
    DataTable data = new DataTable();
    data.Load(datareader);
    data.TableName = "SYSTABLES"; // necessary for writing to xml
    data.WriteXml("tables.xml");
    connection.Close();
