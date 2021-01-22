    static void Main()
    {
        List<Queue<int>> queues = new List<Queue<int>> {
            Build(1,2,3,4,5), Build(6,7,8), Build(9,10,11,12,13)
        };
        foreach (int i in GetItems(queues))
        {
            Console.WriteLine(i);
        }
    }
    static Queue<T> Build<T>(params T[] items)
    {
        Queue<T> queue = new Queue<T>();
        foreach (T item in items)
        {
            queue.Enqueue(item);
        }
        return queue;
    }
