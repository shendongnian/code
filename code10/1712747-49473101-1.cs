    DataSet xDataSet = new DataSet();
    string WorkBookPath = @"[Excel WorkBook Path]";
    //Query one Sheet only. More can be added if necessary
    string[] WBSheetsNames = new string[] { "Sheet1" };
    //Open the Excel document and assign the DataSource to a dataGridView
    xDataSet = Parse(WorkBookPath, WBSheetsNames, null);
    dataGridView1.DataSource = xDataSet.Tables[0];
    dataGridView1.Refresh();
    public DataSet Parse(string fileName, string[] WorkSheets, string[] ranges)
    {
        if (!File.Exists(fileName)) return null;
        string connectionString = string.Format("provider = Microsoft.ACE.OLEDB.12.0; " + 
                                                "data source = {0}; " + 
                                                "Extended Properties = \"Excel 12.0;HDR=YES\"", 
                                                 fileName);
        DataSet data = new DataSet();
        string query = string.Empty;
        foreach (string sheetName in GetExcelSheetNames(connectionString))
        {
            foreach (string WorkSheet in WorkSheets)
                if (sheetName == (WorkSheet + "$"))
                {
                    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        DataTable dataTable = new DataTable();
                        if ((ranges == null) || 
                            (string.IsNullOrEmpty(ranges[0]) || string.IsNullOrEmpty(ranges[1])) ||
                            (int.Parse(ranges[0]) > int.Parse(ranges[1]))) 
                            query = string.Format("SELECT * FROM [{0}]", sheetName);
                        else if ((int.Parse(ranges[0]) == int.Parse(ranges[1])))
                            query = string.Format("SELECT * FROM [{0}] WHERE SrNo = {1}", sheetName, ranges[0]);
                        else
                            query = string.Format("SELECT * FROM [{0}] WHERE (SrNo BETWEEN {1} AND {2}) " +
                                                  "ORDER BY SrNo", sheetName, ranges[0], ranges[1]);
                        con.Open();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                        adapter.Fill(dataTable);
                        data.Tables.Add(dataTable);
                    };
                }
        }
        return data;
    }
    static string[] GetExcelSheetNames(string connectionString)
    {
        string[] excelSheetNames = null;
        using (OleDbConnection con = new OleDbConnection(connectionString))
        {
            con.Open();
            using (DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null))
            {
                if (dt != null)
                {
                    excelSheetNames = new string[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        excelSheetNames[i] = dt.Rows[i]["TABLE_NAME"].ToString();
                    }
                }
            }
        }
        return excelSheetNames;
    }
