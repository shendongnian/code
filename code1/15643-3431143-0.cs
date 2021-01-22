    public class Xyz
    {
       private List<String> _names = new List<String>(); // could also set in constructor
    
       public IEnumerable<String> Names
       {
           get
           {
               return _names;
           }
       }
    
       public void AddName( string name )
       {
           _names.Add( name );
       }
    }
