    static void CopyTable(string sourceConnectionString, string destinationConnectionString, string tableName) {
        // Get rows from source
        var sourceTable = new DataTable();
        using (var sourceConn = new OleDbConnection(sourceConnectionString))
        using (var sourceCmd = new OleDbCommand(tableName, sourceConn) { CommandType = CommandType.TableDirect })
        using (var sourceDA = new OleDbDataAdapter(sourceCmd)) {
            sourceDA.Fill(sourceTable);
        }
        OverwriteTable(sourceTable, destinationConnectionString, tableName);
    }
    static void OverwriteTable(DataTable sourceTable, string destinationConnectionString, string tableName) {
        using (var destConn = new OleDbConnection(destinationConnectionString))
        using (var destCmd = new OleDbCommand(tableName, destConn) { CommandType = CommandType.TableDirect })
        using (var destDA = new OleDbDataAdapter(destCmd)) {
            // Since we're using a single table, we can have the CommandBuilder
            // generate the appropriate INSERT and DELETE SQL statements
            using (var destCmdB = new OleDbCommandBuilder(destDA)) {
                destDA.QuotePrefix = "["; // quote reserved column names
                destDA.QuoteSuffix = "]";
                destDA.DeleteCommand = destCmdB.GetDeleteCommand();
                destDA.InsertCommand = destCmdB.GetInsertCommand();
                // Get rows from destination, and delete them
                var destTable = new DataTable();
                destDA.Fill(destTable);
                foreach (DataRow dr in destTable.Rows) {
                    dr.Delete();
                }
                destDA.Update(destTable);
                // Set rows from source as Added, so the DataAdapter will insert them
                foreach (DataRow dr in sourceTable.Rows) {
                   dr.SetAdded(); 
                }
                destDA.Update(sourceTable);
            }
        }    
    }
