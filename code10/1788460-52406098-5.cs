    private async Task Process() {
      using (BlockingCollection<FakeTask> _queue = new BlockingCollection<FakeTask>()) {
        Task consumer = Task.Run(() => {
          foreach (FakeTask task in _queue.GetConsumingEnumerable()) {
            //TODO: process task - put relevant code here
          }
        });
        // If we produce in UI we don't want separate Task 
        while (!completed) {
          //TODO: put relevant code here 
          _queue.Add(new FakeTask());
        }
        _queue.CompleteAdding();
        await consumer.ConfigureAwait(false); 
      }
    }
