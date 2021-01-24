    public DbSet<Person> Persons { get; set; }
    public class Person
    {
      public int Id { get; private set;}
      public string Name { get; private set;}
      public Address address { get; private set;}
    
      // .. constructor etc
    }
