    //map this in NH
    public virtual User LoggedInCreator {get;set;}
    //Not mapped
    public virtual User CreatorInformation {
        get {
            if(LoggedInCreator != null) return LoggedInCreator;
            return new User {
                    Name = AnonymousCommenterName,
                    Email = AnonymousCommenterEmail,
                    Website= AnonymousCommenterWebsite
                };
        }
    }
    public void SetAnonymouscommenter(string name, string email, string website)
    {
        LoggedInCreator = null;
        AnonymousCommenterName = name;
        AnonymousCommenterEmail = email;
        AnonymousCommenterWebsite = website;
    }
