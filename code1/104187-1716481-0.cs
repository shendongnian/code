    public class myHashT
    {
    public myHashT () { }
    ...
    
    private Hashtable _ht;
    
    public string this[object key]
    {
      get
      {
         return _ht[key].ToString();
      }
      set
      {
         _ht[key] = value;
      }
    } 
  }
