    interface IEmployee
    {
        string FirstName
        { get; set; }
        string LastName
        { get; set; }
    }
    [DataContact]
    class Employee : IEmployee
    {...}
