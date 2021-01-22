    Contact newContact = new Contact();
    newContact.Title.Text = "Victor Fryzel";
    newContact.ContactEntry.Nickname = "nicknameString";
    // ...
    // This example assumes the ContactRequest object (cr) is already set up.
    Contact createdContact = cr.Insert(newContact);
