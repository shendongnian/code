    [Fact]
    public void Manually_Remove_Reference()
    {
        using (var personsContext = new PersonsContext(DbContextOptions))
        {
            var him = new Person { Name = "Him"};
            var her = new Person { Name = "Her"};
            personsContext.Persons.Add(him);
            personsContext.Persons.Add(her);
            personsContext.SaveChanges();
            // this must occur after inserting the two persons!!
            him.SpouseId = her.Id;
            her.SpouseId = him.Id;
            personsContext.SaveChanges();
        }
        using (var personsContext = new PersonsContext(DbContextOptions))
        {
            var her = personsContext.Persons.Find(2);
            her.SpouseId = null;
            var him = personsContext.Persons.Find(1);
            personsContext.Persons.Remove(him);
            personsContext.SaveChanges();
        }
        using (var personsContext = new PersonsContext(DbContextOptions))
        {
            Assert.Null(personsContext.Find<Person>(1));
        }
    }
