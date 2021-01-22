    public interface IDocumentMerger
    {
    }
    public interface IOutputType
    {
    }
    public class EmailMerge : IDocumentMerger
    {
    }
    public class SmsMerge : IDocumentMerger
    {
    }
    public class DocumentMerger<T> where T : IDocumentMerger
    {
      public List<IOutputType> Process()
      { 
          IOutputType result = null;
    
          if (typeof(T) == EmailMerge)
          {
              result = new MailMessage();
          }
    
          // etc..
          // do stuff..
    
          return result;
      }
    }
