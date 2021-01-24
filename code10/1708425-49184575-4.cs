    try {
        var invoices = new List<Invoice>();
        using (var SQLConnection = new SqlConnection(ConnectionString)) {
            SQLConnection.Open();
            using (var cmd = new SqlCommand(query, SQLConnection))
            using (var reader = cmd.ExecuteReader()) {
                while (reader.Read()) {
                    // Note: You should handle nulls if the sql columns are nullable
                    var number = (int)reader["InvoiceNo"];
                    var date = (DateTime)reader["InvoiceDate"];
                    var amount = (int)reader["Amount"];
                    var vat = (int)reader["Vat"];
                    var total = (int)reader["Total"];
                    var iNumAndDate = $"{number}{FileDelimiter}{date.ToString("M/dd/yyyy")}{FileDelimiter}";
                            
                    sw.Write($"{iNumAndDate}{amount}");
                    sw.Write($"{iNumAndDate}{vat}");
                    sw.Write($"{iNumAndDate}{total}");
                    sw.Write(sw.NewLine);
                }
            }
        }
    }
    catch (Exception exception) {
        // TODO: Handle exceptions
    }
