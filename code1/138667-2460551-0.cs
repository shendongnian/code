    public class CurrentOrLegacySelector<T>
    {
    
      public CurrentOrLegacySelector(some type that describe context)
      {   
         // .. do something with the context. 
         // The context could be a boolean or something more fancy.
      }
    
      public List<T> GetNodes(int argument) 
      {
        // Return the result of either current or
        // legacy method based on context information
      }
    }
