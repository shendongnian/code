    public interface IInterfaceService
    {
        IVerb[] GetVerbs(string category);
    }
    public interface IVerb
    {
        string Category { get; }
        string Name { get; }
        void Action();
    }
