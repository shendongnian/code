                using (FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (BufferedStream bufferedStream = new BufferedStream(stream))
                using (StreamReader streamReader = new StreamReader(bufferedStream))
                {
                    string connectionString = @"connectionstring";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            dfdfdf = line.Substring(42, 1);
                            fdfdf = line.Substring(45, 1);
                            DataRow row = dt.NewRow();
                            row["dfdfdf"] = dfdfdf;
                            row["fdfdf"] = fdfdf;
                            dt.Rows.Add(row);
                            if (dt.Rows.Count == batchSize)
                            {
                                try
                                {
                                    Console.WriteLine("Batch sent");
                                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                                    {
                                bulkCopy.ColumnMappings.Add("dfdfdf", "dfdfdf");
                                bulkCopy.ColumnMappings.Add("fdfdf", "fdfdf");
                                        bulkCopy.DestinationTableName = "table";
                                        bulkCopy.WriteToServer(dt);
                                    }
                                    dt.Clear();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                }
                            }
                        }
                        try
                        {
                            Console.WriteLine("Last batch sent");
                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                            {
                                bulkCopy.ColumnMappings.Add("dfdfdf", "dfdfdf");
                                bulkCopy.ColumnMappings.Add("fdfdf", "fdfdf");
                                bulkCopy.DestinationTableName = "table";
                                bulkCopy.WriteToServer(dt);
                            }
                            dt.Clear();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
