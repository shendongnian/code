    using (var personsContext = new PersonsContext(DbContextOptions))
    {
        var him = personsContext.Persons.Find(1);
        var her = personsContext.Persons.Find(2);
        him.SpouseId = null;
        her.SpouseId = null;
        personsContext.SaveChanges(); // Add this line
        personsContext.Persons.Remove(him);
        personsContext.SaveChanges();
    }
