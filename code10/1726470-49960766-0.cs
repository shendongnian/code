    if(!string.IsNullOrEmpty(filter.FirstName))
    {
      students = students.Where(s => s.FirstName.Contains(filter.FirstName));
    }
    
    if(!string.IsNullOrEmpty(filter.LastName))
    {
      students = students.Where(s => s.FirstName.Contains(filter.FirstName));
    }
    
    if(....)
    {
    ...
    }
