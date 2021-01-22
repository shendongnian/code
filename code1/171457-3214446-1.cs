    // It's not clear from your example what the type of Data should
    // be; adjust accordingly.
    var variable1 = Enumerable.Repeat(new { Data = 0 }, 0).AsQueryable();
    if (something == 0)
    {
        //DB = DatabaseObject
        variable1 = from a in DB.Table
                    select new {Data = a};
    }
    int rowTotal = variable1.Count();
