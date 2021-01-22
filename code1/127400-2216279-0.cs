    using (SqlTransaction transaction = destinationConnection.BeginTransaction())
    {
        using (SqlBulkCopy bulkCopy = new SqlBulkCopy( destinationConnection, SqlBulkCopyOptions.KeepIdentity, transaction))
        {
            bulkCopy.BatchSize = 10;
            bulkCopy.DestinationTableName = "dbo.BulkCopyDemoMatchingColumns";
            try
            {
                bulkCopy.WriteToServer(reader);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
            finally
            {
                reader.Close();
            }
        }
    }
