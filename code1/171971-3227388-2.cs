    var oleDbAdapter = new OleDbAdapter("select * from...", table, oleDbConnection);
    oleDbAdapter.InsertCommand = new OleDbCommand("insert into mytable values (?,?)");
    oleDbAdapter.UpdateCommand = new OleDbCommand("update mytable values foo = ?, bar =? where mykey = ?");
    oleDbAdapter.DeleteCommand = new OleDbCommand("delete from mytable where mykey = ?");
    
    oleDbAdapater.InsertCommand.Paramaters.Add(...);
    oleDbAdapater.UpdateCommand.Paramaters.Add(...);
    oleDbAdapater.DeleteCommand.Paramaters.Add(...);
    oleDbAdapater.Update(ds);
