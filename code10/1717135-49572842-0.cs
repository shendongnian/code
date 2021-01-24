    public class BasicOverviewModel<T, TChild>
    {
        public T OverViewModel { get; set; }
    
        public IEnumerable<BasicOverviewModel<TChild>> ChildOverviewModelCollection { get; set; }
    }
