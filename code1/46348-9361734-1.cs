    List<User> list = GetAllUsers();  //Private Method
    if (!sortAscending)
    {
        list = list
               .OrderBy(r => r.GetType().GetProperty(sortBy).GetValue(r,null))
               .ToList();
    }
    else
    {
        list = list
               .OrderByDescending(r => r.GetType().GetProperty(sortBy).GetValue(r,null))
               .ToList();
    }
