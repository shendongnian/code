    public interface IBarCool : IBar
    {}
    public interface IBarAwesome : IBar
    {}
    public interface IBar
    {}
    public interface IParams
    {
        IEnumerable<IBar> Params { get; }
    }
