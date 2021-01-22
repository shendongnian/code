    DataSet dataSet = new DataSet();
    dataSet.add(table);
    using (var adapter = new SqlDbDataAdapter("SELECT * FROM " + tableName, connection))
                {
                    using (var builder = new SqlDbCommandBuilder(adapter))
                    {
    
                        adapter.Fill(dataSet, tableName);
                        using (DataSet newSet = dataSet.GetChanges(DataRowState.Added))
                        {
                            builder.QuotePrefix = "[";
                            builder.QuoteSuffix = "]";
                            adapter.InsertCommand = builder.GetInsertCommand();
                            adapter.Update(newSet, tableName);
                        }
                    }
                }
