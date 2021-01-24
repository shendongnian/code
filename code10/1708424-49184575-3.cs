    try {
        var invoices = new List<Invoice>();
        using (var SQLConnection = new SqlConnection(ConnectionString)) 
        {
            SQLConnection.Open();
            using (var cmd = new SqlCommand(query, SQLConnection))
            using (var reader = cmd.ExecuteReader()) 
            {
                while (reader.Read())
                {
                    invoices.Add(new Invoice {
                        // Note: You should handle nulls if the sql columns are nullable
                        Number = (int)reader["InvoiceNo"],
                        Date = (DateTime)reader["InvoiceDate"],
                        Amount = (int)reader["Amount"],
                        Vat = (int)reader["Vat"],
                        Total = (int)reader["Total"]
                    });
                }
            }
        }
        using (sw = new StreamWriter(FileFullPath, false)) 
        {
            foreach (var invoice in invoices) 
            {
                var iNumAndDate = $"{invoice.Number}{FileDelimiter}{invoice.Date.ToString("M/dd/yyyy")}{FileDelimiter}";
                sw.Write($"{iNumAndDate}{invoice.Amount}");
                sw.Write($"{iNumAndDate}{invoice.Vat}");
                sw.Write($"{iNumAndDate}{invoice.Total}");
                sw.Write(sw.NewLine);
            }
        }
    }
    catch (Exception exception) 
    {
        // TODO: Handle exceptions
    }
