    BlockingCollection<string>() queue = new BlockingCollection<string>();
    void SetUpQueue()
    {
        for (int i=0; i<100; i++) queue.Add(i.ToString());
        queue.CompleteAdding();
    }
    void Worker()
    {
        while (queue.Count > 0 || !queue.IsAddingCompleted)
        {
            var item = queue.Take();
            Foo(item);
        }
    }
    
   
