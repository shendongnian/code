    // Split input into batches with at most "size" items each
    private static IEnumerable<List<T>> Batch<T>(IEnumerable<T> lines, int size) {
      List<T> batch = new List<T>(size);
      foreach (var item in lines) {
        if (batch.Count >= size) {
          yield return batch;
          batch = new List<T>(size);
        }
        batch.Add(item);
      }
      if (batch.Count <= 0)
        yield break;
      else
        yield return batch;
    }
