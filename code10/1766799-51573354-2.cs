    public interface IRing<T, TGroup, TMonoid>
        where TGroup : IGroup<T>
        where TMonoid : IMonoid<T>
    {
       TGroup AdditiveStructure { get; set; }
       TMonoid MultiplicativeStructure { get; set; }
    }
