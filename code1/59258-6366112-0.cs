    [Cache.Cacheable("UserTransactionCache")]
    public DataTable GetAllTransactionsForUser(int userId)
    {
        return new DataProvider().GetAllTransactionsForUser(userId);
    }
    [Cache.TriggerInvalidation("UserTransactionCache")]
    public void DeleteAllTransactionsForUser(int userId)
    {
     ...
    }
