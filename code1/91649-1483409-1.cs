    [WebMethod] 
    public void SavePersonName(long personID, string name){
        Person p = GetPersonByID(personID);
        p.Name = name;
        p.Save();
    }
