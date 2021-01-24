    using (OleDbConnection connection =new OleDbConnection(connectionString))
    {
     var query = "Insert into Purchase (Invoice,VendorName,PurchaseDate,TotalAmt) values (@invoice,@vendor,@purchasedate,@amt)";
            OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, connection);
    
    
     adapter.SelectCommand.Parameters.Add("@invoic", OleDbType.Integer).Value = Convert.ToInt32(Invoice_tx.Text);
     adapter.SelectCommand.Parameters.Add("@vendor", OleDbType.VarChar,100).Value = VendorName_cb.Text;
     adapter.SelectCommand.Parameters.Add("@invoic", OleDbType.Date).Value = PurchaseDate_dt.Value.Date; // I do not know what PurchaseDate_dt.Value.Date  type is, so I leave it to you to convert to approapriate type
     adapter.SelectCommand.Parameters.Add("@CategoryName", OleDbType.Integer).Value = Convert.ToInt32(TotalAmt_tx.Text);
    
     connection.Open();
     DataSet ds = new DataSet();
     adapter.Fill(ds);
    }
    
    
            
