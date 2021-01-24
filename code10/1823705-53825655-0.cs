    public class Person
    {
        string FirstName { get; set {if(value == null) FirstName } = string.Empty;
    
        string MiddleName { get; set; } = string.Empty;
    
        string LastName { get; set; } = string.Empty;
    
        int Age { get; set; }
    }
