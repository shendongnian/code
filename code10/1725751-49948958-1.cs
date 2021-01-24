    protected void BulkImport(DataTable table, string tableName)
    {
        if (!CanConnect)
            return;
    
        var options = SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.CheckConstraints |
                        SqlBulkCopyOptions.UseInternalTransaction;
        using (var bulkCopy = new SqlBulkCopy(_con.ConnectionString, options))
        {
            bulkCopy.DestinationTableName = tableName;
            bulkCopy.BulkCopyTimeout = 30;
            try
            {
                lock(table){
                bulkCopy.WriteToServer(table);
                table.Rows.Clear();
                table.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                var msg = $"Error: Failed the writing to {tableName}, the error:{ex.Message}";
                Logger?.Enqueue(msg);
                try
                {
                    var TE= Activator.CreateInstance(ex.GetType(), new object[] { $"{msg}, {ex.Message}", ex });
                    Logger?.Enqueue(TE as Exception);
                }
                catch
                {
                    Logger?.Enqueue(ex);
                            
                }
                        
            }
            finally
            {
                bulkCopy.Close();
            }
        }
    }
