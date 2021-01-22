    public interface IDocumentMerger
    {
    }
    public class EmailMerge : IDocumentMerger
    {
    }
    public class SmsMerge : IDocumentMerger
    {
    }
    public class DocumentMerger<T> where T : IDocumentMerger, new()
    {
      public List<T> Process()
      {
          var result = new List<T>();
    
          // do stuff..
    
          return result;
      }
    }
