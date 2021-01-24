                    DataTable dt = new DataTable();
                    dt.Columns.Add("IdColumn1", typeof(Guid));
                    dt.Columns.Add("IdColumn2", typeof(Guid));
                    foreach (var item in MyCollection)
                        dt.Rows.Add(item.obj1, item.obj2);
    
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        con.Open();
    
                        using (var bulkCopy = new SqlBulkCopy(con))
                        {
                            bulkCopy.DestinationTableName = "TableName";
                            bulkCopy.ColumnMappings.Add("IdColumn1", "IdColumn1");
                            bulkCopy.ColumnMappings.Add("IdColumn2", "IdColumn2");
                            bulkCopy.WriteToServer(dt);
                        }
                        dt.Dispose();
                    }
