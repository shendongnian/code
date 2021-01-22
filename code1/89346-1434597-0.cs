    public interface IDescription<T>
    {
    }
    public interface IHasDescription<THasDescription, TDescription>
        where THasDescription : IHasDescription<THasDescription, TDescription>
        where TDescription : IDescription<THasDescription>
    {
        IList<TDescription> Descriptions { get; }
    }
