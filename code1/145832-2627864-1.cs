    var range = Enumerable.Range(1, 5);
    var usCustomers = from i in range
                      where i % 2 == 0 
                    select new CustomerInfo 
                          { 
                                        CountryCode = "USA", 
                                        CustomerAddress = "US Address" + i, 
                                        CustomerName = "US Customer Name" + i, 
                                        ForeignAmount = i * 50 
                          };
    var ukCustomers = from i in range
                    where i % 2 != 0
                    select new CustomerInfo 
                          { 
                                        CountryCode = "UK", 
                                        CustomerAddress = "UK Address" + i,
                                        CustomerName = "UK Customer Name" + i,
                                        ForeignAmount = i * 80 
                          };
    lstCustinfo.AddRange(usCustomers.Union(ukCustomers));
