    OleDbConnection xl = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=filename.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
    xl.Open();
    //Get columns
    DataTable dtColumns = xl.GetSchema("Columns", new string[] { null, null, sheetName, null });
    List<string> columns = new List<string>();
    foreach (DataRow dr in dtColumns.Rows)
       columns.Add(dr[3].ToString());
    xl.Close();
