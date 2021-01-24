    void Main()
    {
    
        IDocument doc = new SpecialDocument();
        
        //I added AddResult() to the interface to allow adding results, instead of calling Add() directly on the list.
        doc.AddResult(new SpecialResult());
        Assert.AreEqual(1, doc.Results.Count);
    
        // prooving that the items can be added to a list, and that list can handle all the result types.
        var docs = new List<IDocument>();
        docs.Add(new Document());
        docs.Add(new SpecialDocument());
        var results = docs.SelectMany(d => d.Results)
        // results now contains all results from all documents
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
    
    class Document : Document<Result>
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
