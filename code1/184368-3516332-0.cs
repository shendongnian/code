    interface IInherited : IBase
    {
        // The new is actually unnecessary, hiding is automatic
        new string Property1 { get; set; }
    }
