    // I will only define the fields I want to pass to server
    // this needs to be done at backend level
    class PersonAddressWrapper{
        long PersonAddressID;
        string AddressLine1;
        string AddressLine2;
        string ZipCode;
        string City;
        string Country;
    }
    
    class PersonWrapper{
        long PersonID;
        string Name;
        PersonAddressWrapper[] Addresses; 
    }
    
    [WebMethod]
    public void SavePerson(PersonWrapper pw){
        Person p = GetPersonByID(pw.PersonID);
        p.Name = pw.Name;
        p.Save();
        foreach(PersonAddressWrapper paw in pw.Addresses){
            PersonAddress pa = GetPersonAddressByID(paw.PersonAddressID);
            Copy(pa,paw);
            pa.Save();
        }
    }
