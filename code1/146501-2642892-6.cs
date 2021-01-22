    public interface IDataStrategy
    {
        IEnumerable<Data.Issue> FetchNew();
        IEnumerable<Data.Issue> FetchEnded(); 
    }
