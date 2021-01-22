    public static int? GetFerrariId()
    {
        using (var connection = new SqlConnection("..."))
        {
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                return HandleTranaction(transaction, () =>
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "SELECT CarID FROM Cars WHERE Brand = 'Ferrari'";
                        return (int?)command.ExecuteScalar();
                    }
                });
            }
        }
    }
    
    public static T HandleTranaction<T>(IDbTransaction transaction, Func<T> code)
    {
        try
        {
            var result = code != null ? code.Invoke() : default(T);
            transaction.Commit();
            return result;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
