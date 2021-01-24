    var sql = "SELECT 1 FROM Printers WHERE PrinterID = @IdToCheck";
    using (var command = new SqlCommand(sql, con))
    {
        command.Parameters.AddWithValue("@IdToCheck", tbPrinterID.Text);
        con.Open();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
             ..........
            }
        }
    }
