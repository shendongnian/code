    var TransactionList = db.Transactions.GroupBy(x => x.BatchID).ToList();
    foreach (var group in TransactionList)
    {
        // now group variable is a ... well, group of transactions. :)
        // you can get its key and iterate over sub-collection of transactions in this group.
        Response.Write($"Group {group.Key}:\n");
        foreach (var item in group)
        {
            Response.Write($"    Transaction {item.TTransactionID}\n");
        }
    }
