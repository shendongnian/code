    void Main()
    {
        IDocument doc = new SpecialDocument();
        IEnumerable<Result> result = doc.Results;
        var count = result.Count();
    }
    
    abstract class Document<T> : IDocument where T : Result
    {
        public List<T> Results { get; } = new List<T>();
    
        IEnumerable<Result> IDocument.Results => Results;
    }
    
    abstract class Result
    {
    }
    
    class SpecialDocument : Document<SpecialResult>
    {
    }
    
    class SpecialResult : Result
    {
    }
    
    interface IDocument
    {
        IEnumerable<Result> Results { get; }
    }
