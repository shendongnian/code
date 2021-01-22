    public class MyCollection : IEnumerable
    {
      public IEnumerator GetEnumerator()
      {
        return new MyEnumerator();
      }
    
      private class MyEnumerator
      {
      }
    }
