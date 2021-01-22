    public interface IBase
    {
        string Property1 { get; }
    }
    
    public interface IInherited : IBase
    {
        new string Property1 { get; set; }
    }
