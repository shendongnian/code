    var data = db.Logs.OrderByDescending(l => l.Date)
    
    .Where(l => ((DateTime)l.Date).ToString().Contains(search) 
    
    || l.Name.Contains(search)).ToList(); //ToList() causes the query to execute
    
    //now you can convert the Date
    foreach (var item in data)
    {
        item.Date = item.Date.ToLocalTime();
    }
    
    return View(data.ToPagedList(pageNumber, pageSize));
