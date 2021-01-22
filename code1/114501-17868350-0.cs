    public class User : PriorityQueueNode
    {
        public string Name { get; private set; }
        public User(string name)
        {
            Name = name;
        }
    }
    ...
    HeapPriorityQueue<User> priorityQueue = new HeapPriorityQueue<User>(MAX_USERS_IN_QUEUE);
    priorityQueue.Enqueue(new User("Jason"), 1);
    priorityQueue.Enqueue(new User("Joseph"), 10);
    
    //Because it's a min-priority queue, the following line will return "Jason"
    User user = priorityQueue.Dequeue();
