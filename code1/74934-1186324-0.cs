    public string DisplayName
    {
        get
        {
            if (IsCompany) return CompanyName;
            else return LastName + ", " + FirstName;
        }
    }
