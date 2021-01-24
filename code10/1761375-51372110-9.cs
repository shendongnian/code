    static public void Main(string[] args)
    {
        var queue = new BlockingCollection<string>();
        var task = Task.Run(() => Worker(queue));  //OK to start it first, it'll run in parallel
        for (int i = 0; i < 100; i++)
        {
            var item = "LINE " + i.ToString();
            queue.Add(item);
        }
        queue.CompleteAdding();  //Tell the Worker the queue is complete.
        task.Wait();             //Wait for Worker to finish. 
    }
