    public interface IFilter<T> where T : IFilterParams
    {
        void Apply(ref Mat buffer);
    }
    public interface IFilterParams { }
