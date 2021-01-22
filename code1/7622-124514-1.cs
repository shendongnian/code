    public void MethodA<T>(IList<T> list) where T : ITypeEntity
    {
      IList<T> myIList = new List<T>();
      foreach(T item in list)
      {
        myIList.Add(item);
      }
      b.MethodB(myIList);
    }
