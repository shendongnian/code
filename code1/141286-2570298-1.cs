    Contact newContact = new Contact();
    newContact.Title.Text = "Victor Fryzel";
    newContact.Nickname = new Nickname("Vic");
    // ...
    // This example assumes the ContactRequest object (cr) is already set up.
    Contact createdContact = cr.Insert(newContact);
