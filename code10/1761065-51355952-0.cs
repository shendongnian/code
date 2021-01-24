    [WebMethod]
    public DataTable GetPrintingList()
    {
        DataTable DT = new DataTable();
        DT = CommonModule.Connection.ExecuteDataTable("SELECT QUERY");
        DT.TableName = "tableNameHere";
        return (DT);
    }
