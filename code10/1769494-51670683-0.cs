    public virtual IdentityError DuplicateUserName(string userName)
    {
        return new IdentityError
        {
            Code = nameof(DuplicateUserName),
            Description = Resources.FormatDuplicateUserName(userName)
        };
    }
