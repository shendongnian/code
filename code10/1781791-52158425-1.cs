    var person = new Person 
    {
        // populate Person details...
        User = new User
        {
            // populate user details... Don't worry about PersonId...
        }
    }
    dbContext.Persons.Add(person);
    dbContext.SaveChanges();
