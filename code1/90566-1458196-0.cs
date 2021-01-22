    var fileName = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "Uploads\\");
    string connectionString = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties=""text;HDR=YES;FMT=Delimited""", fileName);
    OleDbConnection oledbConn = new OleDbConnection(connectionString);
    oledbConn.Open();
    var cmd = new OleDbCommand("SELECT * FROM [countrylist.csv]", oledbConn);
