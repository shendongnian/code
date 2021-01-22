    int PermsAvailable = (from up in db.UserPermissions
                          where up.Username == 
                              System.Environment.UserDomainName + "\" + 
                              System.Environment.UserName
                          && up.Publisher == PublisherInput
                          select up).Count();
    if(PermsAvailable)
    {
        var NewBook = New Book with {.Title = TitleInput, .Publisher = PublisherInput};
        db.Books.Add(NewBook);
    }
