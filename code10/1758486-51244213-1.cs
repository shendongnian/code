    public static IEnumerable<T> ExcludePenultimate<T>(IEnumerable<T> source) {
      if (null == source)
        throw new ArgumentNullException(nameof(source));
      Queue<T> queue = new Queue<T>();
      foreach (var item in source) {
        queue.Enqueue(item);
        if (queue.Count > 2) 
          yield return queue.Dequeue();
      }
      if (queue.Count > 2)
        yield return queue.Dequeue();
      if (queue.Count == 2)
        queue.Dequeue();
      yield return queue.Dequeue();
    }
