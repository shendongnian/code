    public class FilterType
    {
       string name;
       int id;
       List<FilterType> fl = new List<FilterType>();
    
       public bool IsEmpty()
       {
          return fl.Count > 0 ? false : true;
       }
    }
