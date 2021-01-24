    string sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID; SELECT * FROM InvoiceItem WHERE InvoiceID = @InvoiceID;";
    using (var connection = My.ConnectionFactory())
    {
        connection.Open();
        using (var multi = connection.QueryMultiple(sql, new {InvoiceID = 1}))
        {
            var invoice = multi.Read<Invoice>().First();
            var invoiceItems = multi.Read<InvoiceItem>().ToList();
        }
    }
