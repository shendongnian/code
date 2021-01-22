    var Query = Context.MyDataSet; //Whatever is the standard base query
    
    if (!string.IsNullOrEmpty(NameFilter))
        Query = Query.Where(e => e.Name.Contains(NameFilter));
    
    if (!string.IsNullOrEmpty(SurnameFilter))
        Query = Query.Where(e => e.Surname.Contains(SurnameFilter));
    
    ...
    
    var Result = Query.ToList(); 
