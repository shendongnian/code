    void Main()
    {
    
        IDocument doc = new SpecialDocument();
        //I added AddResult() to the interface to allow adding results, instead of calling Add() directly on the list.
        doc.AddResult(new SpecialResult()); 
        Assert.AreEqual(1, doc.Results.Count);
    }
    
    abstract class Document<T> : IDocument where T : Result
    {
        public List<T> Results { get; } = new List<T>();
    
        IEnumerable<Result> IDocument.Results => Results;
    
        void IDocument.AddResult(Result result)
        {
            this.Results.Add((T)result);
        }
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
        AddResult(Result result);
    }
