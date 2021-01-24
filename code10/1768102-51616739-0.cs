    using (IDbConnection dbConn = sql.createConnection(ProgOps.connectionString))
    {
       // Start Transaction
       dbConn.Open();
        for (int i = 0; i < itemCount; i++)
		{
			// Get Item Dataset
			dbDataset =  sql.searchItemDetails(itemID[i]);     // SELECT * FROM Items WHERE itemID = @itemID
			
			IDbTransaction dbTrans = sql.createTransaction(dbConn);
			// Update Item
			await sql.updateItem(itemID[i], dbConn, dbTrans);  // UPDATE Items SET price = @price WHERE itemID = @itemID
			
			dbTrans.Commit(); // i think this is the command, pulling from memory
		}
    }
