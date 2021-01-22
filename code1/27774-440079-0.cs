    public class ChildCollection
    {
       // _Children is maintained by the Folder class, hence the internal access specifier
       internal Dictionary<KeyType, Folder> _Children = new Dictionary<KeyType, Folder>;
       public this[KeyType key]
       {
          get
          {
              return _Children[key];
          }
       }
       public IEnumerable<KeyType> Keys
       {
          get
          {
             return _Children.Keys;
          }
       }
    }
