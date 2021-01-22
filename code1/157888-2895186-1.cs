    param = param.ToLower();
    
    var custIdResult = (from Customer c in CustomerCollection
                        where (c.CustomerID.ToLower().Contains(param) &&
                            (countryCodeFilters.Any(item => item.Equals(c.CountryCode))))
                        select c).ToList();
    
    IEnumerable<Customer> source = custIdResult.Count > 0 ? custIdResult : CustomerCollection;
                
    IEnumerable<Customer> q = from Customer ct in source
                                where
                                    ct.CustomerName.ToLower().Contains(param) &&
                                    countryCodeFilters.Any(item => item.Equals(ct.CountryCode))
                                select ct;                                                                  
                       
    if (custIdResult.Count > 0)
        return q.OrderBy(ct => ct.CustomerID);
    
    return q.OrderByDescending(ct => ct.CustomerName);       
            
