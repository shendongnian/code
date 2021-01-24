    static async Task ThreadIt(int threads, int numItems)
    {
          ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
          Enumerable.Range(0, 10).ForEach(x => queue.Enqueue(x));
          List<Task<int>> tasks = new List<Task<int>>();
          Console.WriteLine($"Item limit: {numItems}, threads: {threads}");
          while (!queue.IsEmpty)
          {
              for (int i = 0; i < threads; i++)
              {
                  if(queue.TryDequeue(out int val))
                  {
                       Console.Write($"Adding item: {val} mod 1: {val % threads}. ");
                       tasks.Add(DoSomeWork(val%threads, 500));
                  }
              }
           var result = await Task.WhenAll(tasks);
         }
    }
