    private static readonly object Sync = new object();
    private int _index = 0;
    private readonly List<string> _list = new List<string>() { "blah" ... };
    
    ...
    public string SafeGetNext()
    {
       lock (Sync)
       {
          try
          {
             return _list[_index];
          }
          finally
          {
             _index = _index > _list.Count - 1 ? 0 : _index + 1;
          }
       }
    }
