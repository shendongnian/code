    static private void Worker(BlockingCollection<string> queue)
    {
        while (queue.Count > 0 || !queue.IsAddingCompleted)
        {
            var item = queue.Take();
            Foo(item);
        }
    }
