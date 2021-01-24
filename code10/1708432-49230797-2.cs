    interface ICustomer
    {
        string Name {get; set;}
        ...
    }
    class GuidCustomer : ICustomer
    {
         public Guid Id {get; set;}
         // Todo: implement ICustomer
    }
    class IntCustomer : ICustomer
    {
         public int Id {get; set;}
         // Todo: implement ICustomer
    }
