    interface IList
    {
      void Add (object item);
    }
    class MyList<T> : List<T>, IList
    {
      public void Add (object item)
      {
        base.Add ((T) item); // could put a type check here
      }
    }
    class Program
    {
      static void Main (string [] args)
      {
        SortedDictionary<int, IList>
          dict = new SortedDictionary<int, IList> ();
        dict [0] = new MyList<int> ();
        dict [1] = new MyList<float> ();
        dict [0].Add (42);
        dict [1].Add ("Hello"); // Fails! Type cast exception.
      }
    }
