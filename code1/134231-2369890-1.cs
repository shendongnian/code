    public static Transaction GetMostRecentTransaction(int singleId)
    {
        using (var db = new DataClasses1DataContext())
        {
            return db.Transactions.OrderByDescending(t => t.WhenCreated)
                                  .SingleOrDefault(t => t.Id == singleId);
        }
    }
