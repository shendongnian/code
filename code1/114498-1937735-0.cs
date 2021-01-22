    using System;
    
    class PriorityQueueThatYouDontLike<T> where T: IComparable<T>
    {
        public void Enqueue(T item) { throw new NotImplementedException(); }
        public T Dequeue() { throw new NotImplementedException(); }
    }
    
    class PriorityQueue<T>
    {
        class ItemWithPriority : IComparable<ItemWithPriority>
        {
            public ItemWithPriority(T t, int priority)
            {
                Item = t;
                Priority = priority;
            }
    
            public T Item {get; private set;}
            public int Priority {get; private set;}
    
            public int CompareTo(ItemWithPriority other)
            {
                return Priority.CompareTo(other.Priority);
            }
        }
    
        PriorityQueueThatYouDontLike<ItemWithPriority> q = new PriorityQueueThatYouDontLike<ItemWithPriority>();
    
        public void Enqueue(T item, int priority)
        {
            q.Enqueue(new ItemWithPriority(item, priority));
        }
    
        public T Dequeue()
        {
            return q.Dequeue().Item;
        }
    }
