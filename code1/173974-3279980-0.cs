    public void GetData(string name, string surname, string company)
    {
        DbDataCommand command;
        if (name=!"" && surname!="" && company!="")
        {
            command = GetDataFilteredByFirstNameSurnameCompany(name, surname, company);
        }
        
        if (name=!"" && surname!="")
        {
            command = GetDataFilteredByFirstNameSurname(name, surname);
        }
        
        ...
        
        DbDataReader reader = command.ExecuteReader();
       
        ...
     }
     
