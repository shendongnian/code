    interface IPerson
    {
        IPerson(string name);
    }
    
    interface ICustomer
    {
        ICustomer(DateTime registrationDate);
    }
    
    class Person : IPerson, ICustomer
    {
        Person(string name) { }
        Person(DateTime registrationDate) { }
    }
