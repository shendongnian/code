    class C
    {
       private List<W> _contents = new List<W>();
       public IEnumerable<W> Contents
       {
          get { return _contents; }
       }
       public void Add(W item)
       {
          item.C = this;
          _contents.Add(item);
       }
    }
