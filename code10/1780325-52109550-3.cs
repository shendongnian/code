    string ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Folderpath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=2'";
    if (Extension.Trim() == ".xls")
    {
        // ConStr for Excel 97-2003 Project
        ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Folderpath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=2'";
    }
    OleDbConnection OleCon = new OleDbConnection(ConStr);
    if (OleCon.State == ConnectionState.Closed)
    {
        OleCon.Open();
    }
    // If you know there is only going to be one Sheet
    // - with a variable name, that you can't rememeber...
    name = OleCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
    OleDbCommand OleCom = new OleDbCommand("Select * From [" + name + "]", OleCon);
    OleDbDataAdapter OleAdapObj = new OleDbDataAdapter(OleCom);
    DataTable DatTabObj = new DataTable();
    OleAdapObj.Fill(DatTabObj);
    UploadGridView.DataSource = DatTabObj;
    UploadGridView.DataBind();
