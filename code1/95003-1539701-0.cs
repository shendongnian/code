    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString, options))
                        {
                            ArrayList myList = new ArrayList();
                            foreach (ListItem li in lstOutcome.Items)
                            {
                                myList.Add(li);
                            }
                            bulkCopy.DestinationTableName = "Customers";
                            //amount to bulkcopy at once to prevent slowing with large imports
                            bulkCopy.BatchSize = 200;
                            SqlBulkCopyColumnMapping map1 = new SqlBulkCopyColumnMapping(myList[0].ToString(), "CustomerID");
                            bulkCopy.ColumnMappings.Add(map1);
                            SqlBulkCopyColumnMapping map2 = new SqlBulkCopyColumnMapping(myList[1].ToString(), "Name");
                            bulkCopy.ColumnMappings.Add(map2);
                            SqlBulkCopyColumnMapping map3 = new SqlBulkCopyColumnMapping(myList[2].ToString(), "Address");
                            bulkCopy.ColumnMappings.Add(map3);
                            SqlBulkCopyColumnMapping map4 = new SqlBulkCopyColumnMapping(myList[3].ToString(), "City");
                            bulkCopy.ColumnMappings.Add(map4);
                            SqlBulkCopyColumnMapping map5 = new SqlBulkCopyColumnMapping(myList[4].ToString(), "State");
                            bulkCopy.ColumnMappings.Add(map5);
                            SqlBulkCopyColumnMapping map6 = new SqlBulkCopyColumnMapping(myList[5].ToString(), "ZipCode");
                            bulkCopy.ColumnMappings.Add(map6);
                            SqlBulkCopyColumnMapping map7 = new SqlBulkCopyColumnMapping(myList[6].ToString(), "Phone");
                            bulkCopy.ColumnMappings.Add(map7);
                            SqlBulkCopyColumnMapping map8 = new SqlBulkCopyColumnMapping(myList[7].ToString(), "Email");
                            bulkCopy.ColumnMappings.Add(map8);
