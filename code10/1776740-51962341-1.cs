    var query = context.UserAccounts;
    
    if(email != null)
    {
        query.Where(x => x.Email.Contains(email));
    }
    if (firstname != null)
    {
    	query.Where(x.FirstName.Contains(firstname));
    }
    if (lastname != null))
    {
    	query.Where(x.LastName.Contains(lastname));
    }
    return query.toList();
