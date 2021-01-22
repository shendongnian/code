    [DataMember]
    public IEnumerable<string> Roles
    {
        get
        {
            return ApplicationRoles.Select(r => r.Name).ToList();
        }
        set
        {
            // TODO
        }
    }
