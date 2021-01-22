    var range = Enumerable.Range(1, 5);
    var customers = from i in range
                    select (i % 2 == 0) ?
                          new CustomerInfo 
                          { 
                                        CountryCode = "USA", 
                                        CustomerAddress = "US Address" + i, 
                                        CustomerName = "US Customer Name" + i, 
                                        ForeignAmount = i * 50 
                          }
                          :
                          new CustomerInfo 
                          { 
                                        CountryCode = "UK", 
                                        CustomerAddress = "UK Address" + i,
                                        CustomerName = "UK Customer Name" + i,
                                        ForeignAmount = i * 80 
                          };
    
    lstCustinfo.AddRange(customers);
