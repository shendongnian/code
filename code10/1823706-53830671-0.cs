    public class Person
    {
        string[] FirstNames { get; set {if(value == null) FirstName } = new string[]{};
        string LastName { get; set; } = string.Empty;
        int Age { get; set; }
    }
