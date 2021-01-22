    using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\temp\\test.xls;Extended Properties='Excel 8.0;HDR=Yes'"))
    {
      conn.Open();
      OleDbCommand cmd = new OleDbCommand("CREATE TABLE [Sheet1] ([Column1] string, [Column2] string)", conn);
      cmd.ExecuteNonQuery();
    }
