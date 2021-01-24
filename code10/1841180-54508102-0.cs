var transactionOptions = new TransactionOptions
{
    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
};
using (var tran = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
{
    // Database access logic goes here...
}
Or if you are using the `SqlTransaction` class:
using (var cn = new SqlConnection())
{
    cn.Open();
    using (var tran = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
    {
        // Database access logic...
    }
}
You can find more details in the official SQL server documentation:
https://docs.microsoft.com/en-us/sql/t-sql/language-elements/begin-distributed-transaction-transact-sql?view=sql-server-2017#remarks
There you can see that "snapshot isolation" is not supported on distributed transactions.
