    string conString = @"Provider=Microsoft.JET.OLEDB.4.0;" + @"data source=C:\\myDB.mdb";
    string q = "SELECT * FROM Booking WHERE CheckIn < ?";
    Object result = null;
    using (var conn = new OleDbConnection(conString))
    using (var cmd = new OleDbCommand(q, conn))
    {
        cmd.Parameters.Add("Date", OleDbType.Date).Value = new DateTime(2020, 1, 1);
        Console.WriteLine(q);
        result = cmd.ExecuteScalar();
    }
    if (result == null || result == DBNull.Value)
    {
        result = "0 found";
    }
    MessageBox.Show(result);
