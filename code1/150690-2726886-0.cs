                sqlConn.Open();
                using (var bulkCopy = new SqlBulkCopy(sqlConn))
                {
                    bulkCopy.DestinationTableName = "Table2";
                    bulkCopy.WriteToServer(dataTable);
                }
                sqlConn.Close();
 
