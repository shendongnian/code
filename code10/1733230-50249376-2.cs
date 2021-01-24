                string orderhasvalue = TableQuery.GenerateFilterCondition("Order", QueryComparisons.NotEqual, null);
                string startdatehasvalue = TableQuery.GenerateFilterCondition("StartDate", QueryComparisons.NotEqual, null);
                string enddatehasvalue = TableQuery.GenerateFilterCondition("EndDate", QueryComparisons.NotEqual, null);
                string texthasvalue = TableQuery.GenerateFilterCondition("Text", QueryComparisons.NotEqual, null);
                string startdatenothasvalue = TableQuery.GenerateFilterCondition("StartDate", QueryComparisons.Equal, null);
                string enddatenothasvalue = TableQuery.GenerateFilterCondition("EndDate", QueryComparisons.Equal, null);
    
                TableQuery<CustomerEntity> query1 = new TableQuery<CustomerEntity>().Where(
                    TableQuery.CombineFilters(
                        TableQuery.CombineFilters(
                            TableQuery.CombineFilters(
                                orderhasvalue, TableOperators.And, startdatehasvalue),
                        TableOperators.And, enddatehasvalue),
                    TableOperators.And, texthasvalue)
                );
                TableQuery<CustomerEntity> query2 = new TableQuery<CustomerEntity>().Where(
                    TableQuery.CombineFilters(
                        TableQuery.CombineFilters(
                            TableQuery.CombineFilters(
                                orderhasvalue, TableOperators.And, startdatehasvalue),
                        TableOperators.And, enddatenothasvalue),
                    TableOperators.And, texthasvalue)
                );
                TableQuery<CustomerEntity> query3 = new TableQuery<CustomerEntity>().Where(
                    TableQuery.CombineFilters(
                        TableQuery.CombineFilters(
                            TableQuery.CombineFilters(
                                orderhasvalue, TableOperators.And, startdatenothasvalue),
                        TableOperators.And, enddatenothasvalue),
                    TableOperators.And, texthasvalue)
                );
                
                // Print the fields for each customer.
                foreach (CustomerEntity entity in table.ExecuteQuery(query2))
                {
                    
                    Console.WriteLine("{0}, {1}\t{2}\t{3}\t{4}\t{5}", entity.PartitionKey, entity.RowKey,
                        entity.Order, entity.ConvertTime(entity.StartDate), entity.ConvertTime(entity.EndDate), entity.Text);
                }
