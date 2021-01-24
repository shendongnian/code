    public interface IBarCool : IBar
    {}
    public interface IBarAwesome : IBar
    {}
    public interface IBar
    {}
    public interface IParam
    {
        IEnumerable<IBar> Param { get; }
    }
