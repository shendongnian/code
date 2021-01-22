    public static Transaction GetMostRecentTransaction(int singleId)
    {
        using (var db = new DataClasses1DataContext())
        {
            return (from t in db.Transactions
                    orderby t.WhenCreated descending
                    where t.Id == singleId
                    select t).SingleOrDefault();
        }
    }
