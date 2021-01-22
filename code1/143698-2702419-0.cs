    ContactsService cs = new ContactsService("");
    cs.setUserCredentials("username", "password");            
    string token = cs.QueryAuthenticationToken();
    ContactsService cs2 = new ContactsService("");
    cs2.SetAuthenticationToken(token);
    var results = cs2.Query(new ContactsQuery(ContactsQuery.CreateContactsUri("default")));
