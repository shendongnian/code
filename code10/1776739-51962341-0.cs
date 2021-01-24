    var query = context.UserAccounts;
    
    if(!string.IsNullOrEmpty(email))
    {
        query.Where(x => x.Email.Contains(email));
    }
    if (!string.IsNullOrEmpty(firstname))
    {
    	query.Where(x.FirstName.Contains(firstname));
    }
    if (!string.IsNullOrEmpty(lastname))
    {
    	query.Where(x.LastName.Contains(lastname));
    }
    return query.toList();
