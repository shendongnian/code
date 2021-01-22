    protected User _commenter;
    public virtual User Commenter
    {
        get {
            if(_commenter != null) return _commenter;
            return new User {
                    Name = AnonymousCommenterName,
                    Email = AnonymousCommenterEmail,
                    Website= AnonymousCommenterWebsite
            };
        }
        set {
            bool isAnonymous = value.Id == 0;
            _commenter = isAnonymous ? null : value;
            AnonymousCommenterName = isAnonymous ? value.Name : null;
            AnonymousCommenterEmail = isAnonymous ? value.Email : null;
            AnonymousCommenterWebsite = isAnonymous ? value.Website : null;
        }
    }
