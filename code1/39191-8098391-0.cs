    Interface IPerson
    {
        IPerson(string name);
    }
    
    Interface ICustomer
    {
        ICustomer(DateTime registrationDate);
    }
    
    class Person : IPerson, ICustomer
    {
        Person(string name) { }
        Person(DateTime registrationDate) { }
    }
