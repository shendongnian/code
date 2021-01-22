    public class Stack implements Collection
    {
      ...
      public Iterator iterate()
      {
        return new IteratorImpl();
      }
      private class IteratorImpl implements Iterator
      {
        public boolean hasNext() { ... }
        public Object next() { ... }
      }
    }
