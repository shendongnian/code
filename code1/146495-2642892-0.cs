    public interface IFilterStrategy
    {
        IEnumerable<Data.Issue> FetchNew();
        IEnumerable<Data.Issue> FetchEnded(); 
    }
