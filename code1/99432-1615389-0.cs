    public interface ISearchSystem
    {
      bool TryGet(string parms, out string businessObject);
    }
    
    public class System1Searcher : ISearchSystem
    {
      public System1Searcher(BusinessObjectFactory factory) { _factory = factory; }
      private field BusinessObjectFactory _factory;
      public bool TryGet(string parms, out string businessObject)
      {
        // do internal logic
        return _factory.Create(string stuff);
      }
    }
    
    public class Service
    {
      // is "Validate" the correct metaphor for this logic?
      public string Validate(string parms) 
      {
        string returnValue = null;
        if (new System1Searcher().TryGet(parms, out returnValue)
          return returnValue;
    
        if (new System2Searcher().TryGet(parms, out returnValue)
          return returnValue;
    
        if (new System3Searcher().TryGet(parms, out returnValue)
          return returnValue;
    
        if (new System4Searcher().TryGet(parms, out returnValue)
          return returnValue;
    
        // this message should be written in terms of the logic of this method
        // such as "Parameters invalid"
        throw new ApplicationException("ID Invalid"); 
      }
    }
