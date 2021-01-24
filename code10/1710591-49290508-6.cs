    static List<Person> GetPerson(int countryID, int stateID, int cityID, int zip)
    {
        //create a new expression for the type of person this.
        var paramExpr = Expression.Parameter(typeof(Person));
    
        //next we create a property expression based on the property named "CountryID" (this is case sensitive)
        var property = Expression.Property(paramExpr, "CountryID");
    
        //next we create a constant express based on the country id passed in.
        var constant = Expression.Constant(countryID);
    
        //next we create an "Equals" express where property equals containt. ie. ".CountryId" = 1
        var idEqualsExpr = Expression.Equal(property, constant);
    
        //next we convert the expression into a lamba expression
        var lExpr = Expression.Lambda<Func<Person, bool>>(idEqualsExpr, paramExpr);
    
        //finally we query our dataset
        return persons.AsQueryable().Where(lExpr).ToList();
    }
