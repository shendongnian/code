    public class Person
    {
    string firstName;
    public string FirstName
    {
    get{return firstName;}
    set
    {
    if (String.IsNullOrEmpty(value))
    throw new Exception("First name should be provided!");
    firstName = value;
    }
    }
    }
