    public person CreatePerson(string name, decimal basicSalary, int countryId) {
        var person = new person {
            name = name,
            basicSalary = basicSalary
        };
    
        var country = _dbContext.Country.Find(countryId);
        person.country = country;
        
        _dbContext.Person.Add(person);
        _dbContext.SaveChanges();
    
        return person;
    }
