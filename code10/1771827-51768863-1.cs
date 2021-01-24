    // Get the defaultContacts
    var defaultContacts = await graphClient
        .Me
        .Contacts
        .Request()
        .GetAsync();
    
    // Get the contactFolders
    var contactFolders = await graphClient
        .Me
        .ContactFolders
        .Request()
        .GetAsync();
    
    // Use this to store the contact from all contact folder.
    List<Contact> contactFolderContacts = new List<Contact>();
    
    if (contactFolders.Count > 0) {
        for (int i = 0; i < contactFolders.Count; i++) {
            var folderContacts = await graphClient
                .Me
                .ContactFolders[contactFolders[i].Id]
                .Contacts
                .Request()
                .GetAsync();
    
            contactFolderContacts.AddRange(folderContacts.AsEnumerable());
        }
    
        // This will combine the contact from main folder and the additional folders.
        contactFolderContacts.AddRange(defaultContacts.AsEnumerable());
    } else {
        // This user only has the default contacts folder
        contactFolderContacts.AddRange(defaultContacts.AsEnumerable());
    }
    
    // Use this to test the result.
    foreach (var item in contactFolderContacts) {
        Debug.WriteLine("first:" + item.EmailAddresses);
    }
