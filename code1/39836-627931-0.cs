    // create a principal object representation to describe
    // what will be searched 
    UserPrincipal user = new UserPrincipal(adPrincipalContext);
    
    // define the properties of the search (this can use wildcards)
    user.Enabled = false;
    user.Name = "user*";
    
    // create a principal searcher for running a search operation
    PrincipalSearcher pS = new PrincipalSearcher();
    
    // assign the query filter property for the principal object 
    // you created
    // you can also pass the user principal in the 
    // PrincipalSearcher constructor
    pS.QueryFilter = user;
    
    // run the query
    PrincipalSearchResult<Principal> results = pS.FindAll();
    
    Console.WriteLine("Disabled accounts starting with a name of 'user':");
    foreach (Principal result in results)
    {
        Console.WriteLine("name: {0}", result.Name);
    }
