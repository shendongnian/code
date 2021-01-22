    public class Globals
    {
      private Context _current;
      private Dictionary<int, string> _dbValues;
    
      public Dictionary<int, string> DbValues
      {
        get
        {
          if (_dbValues == Null)
          {
            // ... Load our data here
          }
          return _dbValues;
        }
        set
        {  
      }
      public Globals Current
      {
        get
        {
          if(_current == Null)
            _current = Context();
          return _current;
        }
      }    
    
      private Globals()
      {  }
    
    
    }
    // Can be used this way
    var value = Globals.Current.DbValues[key1];
