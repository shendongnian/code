                while ((line = r.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    // Skip the column names row
                    if (parts[0] == "id") continue;
                    try
                    {
                        CustomerData dbp = new CustomerData
                        { 
                            CustomerId = Convert.ToInt32(parts[0]),
                            CustomerName = parts[1],
                            CustomerState = parts[2],
                            ProductId = Convert.ToInt32(parts[3]),
                            QuantityBought = Convert.ToInt32(parts[4]),
                        };
                        customerdata.Add(dbp);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, "Got exception."); 
                        logger.Info(line);
                    }
                }
