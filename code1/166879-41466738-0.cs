    // Using an OleDbConnection to connect to excel
    var cs = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFile};Extended Properties=""Excel 12.0 Xml; HDR = Yes; IMEX = 2"";Persist Security Info=False";
    var con = new OleDbConnection(cs);
    con.Open();
    // Using OleDbCommand to read data of the sheet(sheetName)
    var cmd = new OleDbCommand($"select * from [{sheetName}$]", con);
    var ds = new DataSet();
    var da = new OleDbDataAdapter(cmd);
    da.Fill(ds);
    // Convert DataSet to Xml
    using (var fs = new FileStream(xmlFile, FileMode.CreateNew))
    {
        using (var xw = new XmlTextWriter(fs, Encoding.UTF8))
        {
            ds.WriteXml(xw);
        }
    }
