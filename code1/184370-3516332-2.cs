    interface IInherited : IBase
    {
        // The new is actually unnecessary (you get warnings though), hiding is automatic
        new string Property1 { get; set; }
    }
