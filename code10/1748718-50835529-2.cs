    // Split input into batches with at most "size" items each
    private static IEnumerable<T[]> Batch<T>(IEnumerable<T> lines, int size) {
      List<T> batch = new List<T>(size);
      foreach (var item in lines) {
        if (batch.Count >= size) {
          yield return batch.ToArray();
          batch.Clear();
        }
        batch.Add(item);
      }
      if (batch.Count > 0)   // tail, possibly incomplete batch
        yield return batch.ToArray();
    }
