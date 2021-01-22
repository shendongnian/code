    public class DatosCollection {
    
      public T this[string name] {
        get { return (T)HttpContext.Current.Session[name]; }
        set { HttpContext.Current.Session[name] = value; }
      }
    
    }
    
    private _collection = new DatosCollection();
    
    public DatosCollection Datos { get { return _collection; } }
