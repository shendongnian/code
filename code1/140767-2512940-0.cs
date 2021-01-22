    interface IDerived : IBase
    {
        string Foo { get; set; }
    }
    interface IBase
    {
        DateTime LastRunDate { get; set; }
    }
