    class PriorityQueue {
    
        private readonly Queue normalQueue = new Queue();
        private readonly Queue urgentQueue = new Queue();
    
        public object Dequeue() {
            if (urgentQueue.Count > 0) { return urgentQueue.Dequeue(); }
            if (normalQueue.Count > 0) { return normalQueue.Dequeue(); }
            return null;
        }
    
        public void Enqueue(object item, bool urgent) {
            if (urgent) { urgentQueue.Enqueue(item); }
            else { normalQueue.Enqueue(item); }
        }
    }
