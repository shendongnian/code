        using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + name, conn))
        {
            // this is the proper way to transfer rows
            adapter.AcceptChangesDuringFill = false;
            QuoteDataSet ds = new QuoteDataSet();
            adapter.Fill(ds, tableName);
            Console.WriteLine("Num rows loaded is " + ds.Tags.Rows.Count);
            InsertData(ds, tableName);
        }
