    while(true) {
        T item;
        lock(lockObj) {
            if(queue.Count == 0) { // empty
                Monitor.Wait(lockObj);
                continue; // ensure there is genuinely something to do
            }
            item = queue.Dequeue();
        }
        // TODO: process item
    }
    ...
    void Add(T item) {
        lock(lockObj) {
            queue.Enqueue(item);
            if(queue.Count == 1) { // first
                Monitor.PulseAll(lockObj);
            }
        }
    }
