    public  Person ToPerson(dbPerson row, bool getDetails)
    {
         Person result = new Person{
                                    ID = row.ID,
                                    FirstName = row.FirstName,
                                    LastName = row.LastName};
         if(getDetails)
         {
             result.Roles = getRoles(row.ID)};
         }
    
         return result;
    }
