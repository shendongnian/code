    // The name of the EXCEL-SHEET in the Excel File.
    string name = "Items$";
    // The Pathname of the Excel File
    string path = Server.MapPath(StyleOperationsFileUpload.FileName);
    // Getting the Extension to check whether it's old or new Office file.
    string Extension = Path.GetExtension(path).ToLower();
    // Default ConStr for "new" Excel (> 2003)
    string ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=2'";
    if (Extension.Trim() == ".xls")
    {
        // ConStr for old Excel 97-2003 Project
        ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=2'";
    }
    OleDbConnection OleCon = new OleDbConnection(ConStr);
    if (OleCon.State == ConnectionState.Closed)
    {
        OleCon.Open();
    }
    // It seems that there might be some confusion about what that Sheet is called, so I would suggest checking up on what's in there.. 
    bool doThatThing = false;
    DataTable Sheets = OleCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    foreach (DataRow Sheet in Sheets.Rows)
    {
        // SheetsInFile:
        //sheetsInFile.Text += Sheets["TABLE_NAME"].ToString();
        if (name == dr["TABLE_NAME"].ToString())
            doThatThing = true;
    }
    if (doThatThing)
    {
        OleDbCommand OleCom = new OleDbCommand("Select * From [" + name + "]", OleCon);
        OleDbDataAdapter OleAdapObj = new OleDbDataAdapter(OleCom);
        DataTable DatTabObj = new DataTable();
        OleAdapObj.Fill(DatTabObj);
        UploadGridView.DataSource = DatTabObj;
        UploadGridView.DataBind();
    }
    // Don't forget to close Connection
    OleCon.Close();
