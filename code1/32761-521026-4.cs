    static public void InitiateCopyProcessA()
    {
        DataSet tablesA;
        tablesA = DatabaseHandling.getDataSetA();
        int i = 0;
        string tableName = "";
        try
        {
            foreach (DataTable table in tablesA.Tables)
            {
                tableName = table.TableName;  // for debugging the exception
                CopyTable(connectionstringA, connectionstringB, table.TableName);
            }
        }
        catch(Exception ex)
        {
            throw new Exception("Error updating " + tableName, ex);
        }
    }
