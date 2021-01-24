    var newEarnings = from employee in EmployeeList
                                  select new Earnings
                                  {
                                      Name = employee.Name,
                                      LastName = employee.LastName,
                                      Bank = employee.Bank,
                                      Account = employee.Account,
                                      Money = (from daysData in ProductList
                                               from product in daysData.Products
                                               where employee.Name == product.EmployeeName && employee.LastName == product.EmployeeLastName
                                               select product).Sum(p => p.Count * p.Price)
                                  };
    
                EarningsList = EarningsList.Union(newEarnings).ToList();
