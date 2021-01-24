csharp
        static void Main(string[] args)
        {
            var e = new AsyncEnumerable<int>(async yield =>
            {
                var threadCount = 10;
                var maxItemsOnQueue = 20;
                var queue = new ConcurrentQueue<int>();
                var consumerLimiter = new SemaphoreSlim(initialCount: 0, maxCount: maxItemsOnQueue + 1);
                var produceLimiter = new SemaphoreSlim(initialCount: maxItemsOnQueue, maxCount: maxItemsOnQueue);
                // Kick off producers
                var producerTasks = Enumerable.Range(0, threadCount)
                    .Select(index => Task.Run(() => ProduceAsync(queue, produceLimiter, consumerLimiter)));
                // When production ends, send a termination signal to the consumer.
                var endOfProductionTask = Task.WhenAll(producerTasks).ContinueWith(_ => consumerLimiter.Release());
                // The consumer loop.
                while (true)
                {
                    // Wait for an item to be produced, or a signal for the end of production.
                    await consumerLimiter.WaitAsync();
                    // Get a produced item.
                    if (queue.TryDequeue(out var item))
                    {
                        // Tell producers that they can keep producing.
                        produceLimiter.Release();
                        // Yield a produced item.
                        await yield.ReturnAsync(item);
                    }
                    else
                    {
                        // If the queue is empty, the production is over.
                        break;
                    }
                }
            });
            e.ForEachAsync((item, index) => Console.WriteLine($"{index + 1}: {item}")).Wait();
        }
        static async Task ProduceAsync(ConcurrentQueue<int> queue, SemaphoreSlim produceLimiter, SemaphoreSlim consumerLimiter)
        {
            var rnd = new Random();
            for (var i = 0; i < 10; i++)
            {
                await Task.Delay(10);
                var value = rnd.Next();
                await produceLimiter.WaitAsync(); // Wait for the next production slot
                queue.Enqueue(value); // Produce item on the queue
                consumerLimiter.Release(); // Notify the consumer
            }
        }
