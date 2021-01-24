    interface ICanBeHeldInFirstContainer
    { }
    public interface IFirstSub : IBase, ICanBeHeldInFirstContainer
    {
        string Description { get; set; }
    }
    public interface ISecondSub : IBase, ICanBeHeldInFirstContainer
    {
        decimal Total { get; set; }
    }
