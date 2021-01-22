    public class interface Person : IPerson
    {
        int ID { get; protected set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get { return FirstName + " " + LastName; } }
    }
