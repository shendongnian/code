    public void SomeDALMethod(string connectionString)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var transaction = connection.BeginTransaction();
            var command1 = new SqlCommand("tblOrders_CreateNewOrder", connection, transaction)
			               	{
			               		CommandType = CommandType.StoredProcedure
			               	};
            var command2 = new SqlCommand("tblProducts_RecalculateStock", connection, transaction)
			               	{
			               		CommandType = CommandType.StoredProcedure
			               	};
            try
            {
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Commit failed
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    // Rollback failed
                }
            }			
        }
    }
