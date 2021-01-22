    var inventoryFile = "Inventory.xlsx"; //ID,Item
    var databaseFile = "Database.xlsx"; //ID,Item,Type,SN,LastSeen
    var connectionFormatter = "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source=\"{0}\";Mode=ReadWrite;" +
        "Extended Properties=\"Excel 12.0 Xml;HDR=Yes;\";";
    var inventoryConnectionString = string.Format(connectionFormatter,
                                                  inventoryFile);
    var databaseConnectionString = string.Format(connectionFormatter,
                                                 databaseFile);
    using (var inventoryConnection =
                     new OleDbConnection(inventoryConnectionString))
    using (var databaseConnection =
                     new OleDbConnection(databaseConnectionString))
    {
        if (inventoryConnection.State != ConnectionState.Open)
            inventoryConnection.Open();
        if (databaseConnection.State != ConnectionState.Open)
            databaseConnection.Open();
        var lastSeenCmdString = "SELECT MAX(LastSeen) FROM [Sheet1$]";
        var lastSeenCommand = new OleDbCommand(lastSeenCmdString,
                                               databaseConnection);
        var lastSeen = lastSeenCommand.ExecuteScalar();
        var inventorySelectCmdString = "SELECT ID, Item FROM [Sheet1$]";
        var inventoryCmd = new OleDbCommand(inventorySelectCmdString,
                                            inventoryConnection);
        var table = new DataTable();
        var idCol = table.Columns.Add("ID", typeof(int));
        var itemCol = table.Columns.Add("Item", typeof(int));
        var inventoryDataAdapter = new OleDbDataAdapter(inventoryCmd);
        var databaseDataAdapter = new OleDbDataAdapter();
        var updateLastSeenCmdString =
                        "UPDATE [Sheet1$] SET LastSeen=NOW() WHERE Item=?";
        var updateCmd = new OleDbCommand(updateLastSeenCmdString,
                                         databaseConnection);
        var parameter = updateCmd.Parameters.Add("Item",
                                                 OleDbType.Integer,
                                                 0,
                                                 "Item");
        databaseDataAdapter.UpdateCommand = updateCmd;
        inventoryDataAdapter.Fill(table);
        table.AcceptChanges();
        foreach (var row in table.Rows.OfType<DataRow>())
            row.SetModified();
        databaseDataAdapter.Update(table);
        var notSeenCmdString = "SELECT ID,Item,Type,SN,LastSeen " +
                               "FROM [Sheet1$]" +
                               "WHERE LastSeen <= ?";
        var notSeenCmd = new OleDbCommand(notSeenCmdString,
                                          databaseConnection);
        notSeenCmd.Parameters.Add("LastSeen", OleDbType.Date).Value = lastSeen; 
        databaseDataAdapter.SelectCommand = notSeenCmd;
        var missingInventory = new DataTable();
        databaseDataAdapter.Fill(missingInventory);
        foreach (var row in missingInventory.Rows.OfType<DataRow>())
            Console.WriteLine("ID: {0} Item:{1} Type:{2} SN:{3} LastSeen:{4}", 
                              row.ItemArray);
    }
