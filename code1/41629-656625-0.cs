    public class Person
    {
      public int ID { get; protected set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string FullName { get { return FirstName + " " + LastName; } }
    }
