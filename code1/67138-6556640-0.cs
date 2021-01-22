    interface IGenericPerson
    {
        int ID { get; set; }
        string Name { get; set; }
    }
    interface IOperator : IGenericPerson
    {
        bool IsAdmin { get; set; }
    }
