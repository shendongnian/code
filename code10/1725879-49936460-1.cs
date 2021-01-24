    //Get the last testpart of the test.
    TestPart item = context.TestPart
                           .Include(tp => tp.Jobs)  //possibly optional dependent on lazy/eager loading.
                           .OrderByDescending(tp=>tp.Id)
                           .First(tp => tp.TestId == 100);
    
    //Check if this item fits the criteria
    bool isValid = 
              item.Status == 1 
              && item.Jobs.All(j => j.Type == "Recurring");
