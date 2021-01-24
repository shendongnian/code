    public static IEnumerable<Product> CreateProducts(IEnumerable<Worker> workers)
    {
        var queue = new ConcurrentQueue<Product>();
        var task = Task.Run(() => ConvertProducts(workers.GetEnumerator(), queue));
        while (true)
        {
            while (queue.Count > 0)
            {
                Product product;
                var ok = queue.TryDequeue(out product);
                if (ok) yield return product;
            }
            if (task.IsCompleted && queue.Count == 0) yield break;
            Monitor.Wait(queue, 1000);
        }
    }
    private static async Task ConvertProducts(IEnumerator<Worker> input, ConcurrentQueue<Product> output)
    {
        while (input.MoveNext())
        {
            var current = input.Current;
            var product = await current.CreateProductAsync();
            output.Enqueue(product);
            Monitor.Pulse(output);
        }
    }
