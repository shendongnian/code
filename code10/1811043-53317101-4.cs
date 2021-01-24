    public int? GetCount(string type, string value)
    {
        switch (type)
        {
            case "User":
                return GetCountFromDB<User>(x => x.FirstName == value);
    
            case "Car":
                return GetCountFromDB<Car>(x => x.Model == value);
    
            case "Company":
                return GetCountFromDB<Company>(x => x.CompanyName == value);
    
            default:
                return null;
        }
    }
