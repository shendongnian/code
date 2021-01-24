    void HandToConsumerBlockingUntilAvailable(CanMessage[] messages) {
        lock(_queue) {
            _queue.Enqueue(messages);
            if(queue.Length == 1) Monitor.PulseAll(_queue);
        }
    }
    CanMessage[] BlockUntilAvailableFromProducer() {
        lock(_queue) {
            if(_queue.Length != 0) return _queue.Dequeue();
            Monitor.Wait(_queue); // wait for pulse
        }
    }
    private readonly Queue<CanMessage[]> _queue = new Queue<CanMessage[]>;
