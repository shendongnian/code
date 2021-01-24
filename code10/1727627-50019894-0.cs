    // Get the number of items in the Contacts folder.
    ContactsFolder contactsfolder = ContactsFolder.Bind(service, WellKnownFolderName.Contacts);
    
    // Set the number of items to the number of items in the Contacts folder or 50, whichever is smaller.
    int numItems = contactsfolder.TotalCount < 50 ? contactsfolder.TotalCount : 50;
    
    // Instantiate the item view with the number of items to retrieve from the Contacts folder.
    ItemView view = new ItemView(numItems);
    
    // To keep the request smaller, request only the display name property.
    view.PropertySet = new PropertySet(BasePropertySet.IdOnly, ContactSchema.DisplayName);
    
    // Retrieve the items in the Contacts folder that have the properties that you selected.
    FindItemsResults<Item> contactItems = service.FindItems(WellKnownFolderName.Contacts, view);
    
    // Display the list of contacts. 
    foreach (Item item in contactItems)
    {
        if (item is Contact)
        {
            Contact contact = item as Contact;
            if (contact.DateTimeCreated.Date == DateTime.Today.Date)
            {
               //Notify - Newly created contact
            }
            if (contact.LastModifiedTime.Date == DateTime.Today.Date)
            {
               //Notify - Newly modified contact
            }
        }
    }
