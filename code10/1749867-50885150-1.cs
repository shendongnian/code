    static IEnumerable<Product> CreateProducts(IEnumerable<IWorker> workers)
    {
        var products = new BlockingCollection<Product>(3);
        Task.Run(async () => // On the thread pool...
        {
            foreach (IWorker worker in workers)
            {
                Product product = await worker.CreateProductAsync(); // Create products serially.
                products.Add(product); // Enqueue the product, blocking if the queue is full.
            }
            products.CompleteAdding(); // Notify GetConsumingEnumerable that we're done.
        });
        return products.GetConsumingEnumerable();
    }
