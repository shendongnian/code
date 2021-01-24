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
            products.CompleteAdding(); // We're done; signal the 'while' loop below to exit.
        });
        while (true)
        {
            Product product;
            try
            {
                product = products.Take(); // Dequeue the next product, blocking if the queue is empty.
            }
            catch (InvalidOperationException) // CompleteAdding was called.
            {
                break;
            }
            yield return product;
        }
    }
