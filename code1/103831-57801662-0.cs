C#
using (var transactionScope = new TransactionScope())
{
    using (var connection = new SqlConnection("Server=localhost;Database=TestDB;Trusted_Connection=True"))
    {
        connection.Open();
        new SqlCommand($"INSERT INTO TestTable VALUES('This will be rolled back later')", connection).ExecuteNonQuery();
        var someNestedTransaction = connection.BeginTransaction();
        someNestedTransaction.Rollback();
        new SqlCommand($"INSERT INTO TestTable VALUES('This is not in a transaction, and will be committed')", connection).ExecuteNonQuery();
    }
    throw new Exception("Exiting.");
    transactionScope.Complete();
}
  [1]: https://stackoverflow.com/questions/57762733/how-to-detect-that-rollback-has-occurred
