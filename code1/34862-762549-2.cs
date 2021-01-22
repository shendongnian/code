    public interface Collection
    {
      ...
      
      public Iterator iterate();
    }
    public interface Iterator
    {
      public boolean hasNext();
      public Object next();
    }
