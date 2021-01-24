    void HandToConsumerBlockingUntilAvailable(CanMessage[] messages) {
        lock(_queue) {
            if(_queue.Length != 0) Monitor.Wait(_queue); // block until space
            _queue.Enqueue(messages);
            if(queue.Length == 1) Monitor.PulseAll(_queue); // wake consumer
        }
    }
    CanMessage[] BlockUntilAvailableFromProducer() {
        lock(_queue) {
            if(_queue.Length == 0) Monitor.Wait(_queue); // block until work
            var next = _queue.Dequeue();
            Monitor.Pulse(_queue); // wake producer
            return _next;
        }
    }
    private readonly Queue<CanMessage[]> _queue = new Queue<CanMessage[]>;
