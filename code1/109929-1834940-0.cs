    List<Item> myList = FetchDataFromDatabase();
    
    decimal currentTotal = 0;
    var query = myList
                   .OrderBy(i => i.Date)
                   .Select(i => 
                               {
                                 currentTotal += i.Amount;
                                 return new { 
                                                Date = i.Date, 
                                                Amount = i.Amount, 
                                                RunningTotal = currentTotal 
                                            };
                               }
                          );
    foreach (var item in query)
    {
        //do with item
    }
