    var query = context.UserAccounts;
    if(email!= null)
    {
        query = query.Where(x => x.Email.Contains(email));
    }
    if (firstname != null)
    {
        query = query.Where(x => x.FirstName.Contains(firstname));
    }
    if (lastname != null)
    {
        query = query.Where(x => x.LastName.Contains(lastname));
    }
    return query.toList();
