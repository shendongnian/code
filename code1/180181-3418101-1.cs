    List<int> list = new List<int>(Enumerable.Range(0, 100));
    ICollection collection = list as ICollection;
    if(collection != null)
    {
      Console.WriteLine(collection.Count);
    }
