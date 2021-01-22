    RequestSettings settings = new RequestSettings("yourAppName", appDomainName, DomainConsumerSecret, userId, appDomainName);   //the userId is the pure id without "@yourdomain.com" 
    ContactsRequest  contactsRequest = new ContactsRequest(settings);
    Uri feedUri = new Uri(ContactsQuery.CreateContactsUri("default"));
    Contact createdEntry = contactsRequest.Insert<Contact>(feedUri, contact);  
           
