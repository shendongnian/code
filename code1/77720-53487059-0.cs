    var filePath = "TestFiles/Test.xlsx";
    var strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=0\"";
    using (var conn = new OleDbConnection(strConn))
    {
                    conn.Open();
    ...
    }
