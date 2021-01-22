    foreach(List<Order> orderbatch in orders.Batch(100))
    {
      db.Orders.InsertOnSubmit(orderbatch); 
      db.SubmitChanges();   
    }
    
    
    public static IEnumerable<List<T>> Batch<T>(this IEnumerable<T> source, int batchAmount)
    {
      List<T> result = new List<T>();
      foreach(T t in source)
      {
        result.Add(t);
        if (result.Count == batchSize)
        {
          yield return result;
          result = new List<T>();
        }
      }
      if (result.Any())
      {
        yield return result;
      }
    }
