    abstract class Document<T> where T : Result
    {
        public List<T> Results { get; } = new List<T>();
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
