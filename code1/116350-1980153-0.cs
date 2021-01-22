    using (TransactionScope scope = new TransactionScope())
    {
        conn1.Open(); //Open connection to db1
        conn2.Open(); //Open connection to db2
        // Don't forget to commit the transaction so it won't rollback
        scope.Commit()
    }
