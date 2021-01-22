    public interface IBase
    {
        string Property1 { get; }
    }
    
    public interface IInherited : IBase
    {
        void SetProperty1(string value);
    }
