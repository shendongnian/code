    Contact myPerson = Contact.GetContactById(15);
    
    // get all contacts for the customer
    ContactCollection contacts = customer.GetContacts();
    
    // replaces the contact in the collection with the 
    // myPerson contact with the same ContactID.
    contacts.ReplaceAt(myPerson);
    
    // saves the changes to the contacts and the customer
    // customer.Save();
