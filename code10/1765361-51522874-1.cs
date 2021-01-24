    public void ExecuteInBatches<T>(IEnumerable<T> source, int batchSize,
            Action<List<T>> action)
    {
        List<T> batch = new List<T>();
        foreach(var item in source) {
            batch.Add(item);
            if(batch.Count == batchSize) {
                 action(batch);
                 batch = new List<T>(); // in case the callback stores it
            }
        }
        if (batch.Count != 0) {
            action(batch); // any leftovers
        }
    }
