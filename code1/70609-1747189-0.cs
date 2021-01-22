    public class Person
    {
         string FirstName { get; set; }
         string LastName {get; set; }
         string FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }
    }
