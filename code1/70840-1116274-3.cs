    object sync = new Object();
    var queue = new Queue<TriggerData>();
    public void EnqueueTriggers(IEnumerable<TriggerData> triggers) {
      lock (sync) {
        foreach (var t in triggers) {
          queue.Enqueue(t);
        }
        Monitor.Pulse(sync);  // Use PulseAll if there are multiple worker threads
      }
    }
    void WorkerThread() {
      while (!exit) {
        TriggerData job = DequeueTrigger();
        // Do work
      }
    }
    private TriggerData DequeueTrigger() {
      lock (sync) {
        if (queue.Count > 0) {
          return queue.Dequeue();
        }
        while (queue.Count == 0) {
          Monitor.Wait(sync);
        }
        return queue.Dequeue();
      }
    }
