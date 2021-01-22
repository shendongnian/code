    Contact contact = new Contact();
    contact = dbContext.Contacts.Single(c => c.contactTypeId == 1234);
    contact.contactTypeId = 4;
    dbContext.AddObject(contact);
    dbContext.SaveChanged();
