    public DataSet GetDataSetFromFile()
    {
        string strFileName = _FilePath;
        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;";
        strConn += "Data Source= " + strFileName + "; Extended Properties='Excel 8.0;HDR=No;IMEX=1'";
        OleDbConnection ObjConn = new OleDbConnection(strConn);
        ObjConn.Open();
        string strSheetName = getSheetName(ObjConn);
        OleDbCommand ObjCmd = new OleDbCommand("SELECT * FROM [" + strSheetName + "]", ObjConn);
        OleDbDataAdapter objDA = new OleDbDataAdapter();
        objDA.SelectCommand = ObjCmd;
        DataSet ObjDataSet = new DataSet();
        objDA.Fill(ObjDataSet);
        ObjConn.Close();
        return ObjDataSet;
    }
    
    private string getSheetName(OleDbConnection ObjConn)
    {
        string strSheetName = String.Empty;
        try
        {
            System.Data.DataTable dtSheetNames = ObjConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dtSheetNames.Rows.Count > 0)
            {
                strSheetName = dtSheetNames.Rows[0]["TABLE_NAME"].ToString();
            }
            return strSheetName;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to get the sheet name", ex);
        }
    }
