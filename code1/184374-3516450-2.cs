    interface IBase
    {
        string Property1 { get; }
    }
    
    interface IInherited : IBase
    {
        new string Property1 { get; set; }
    }
