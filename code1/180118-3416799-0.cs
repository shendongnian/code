    public interface IA : ICommon {...}
    public interface IB : ICommon {...}
    public interface ICommon
    {
        int Owner {get;}
        string Version();
    }
