        private static void InsertTable(DataTable dt)
        {
            dt.AcceptChanges();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ToString()))
                {
                    //Destination Table is the same as the source.
                    bulkCopy.DestinationTableName = dt.TableName;
                    try
                    {
                        // Write from the source to the destination.
                        bulkCopy.BulkCopyTimeout = 600;
                        bulkCopy.WriteToServer(dt);
                    } 
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                }
            
        }
        private static void InsertTableWithIdentity(DataTable dt)
        {
            dt.AcceptChanges();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ToString(), SqlBulkCopyOptions.KeepIdentity))
            {
                //Destination Table is the same as the source.
                bulkCopy.DestinationTableName = dt.TableName;
                try
                {
                    // Write from the source to the destination.
                    bulkCopy.BulkCopyTimeout = 600;
                    bulkCopy.WriteToServer(dt);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }
