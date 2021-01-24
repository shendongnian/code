    static async Task ThreadIt(int threads, int numItems)
    {
          List<Task<int>> tasks = new List<Task<int>>();
          Console.WriteLine($"Item limit: {numItems}, threads: {threads}");
          for (int i = 0; i < numItems; i++)
          {
               Console.Write($"Adding item: {i} mod 1: {i % threads}. ");
               tasks.Add(DoSomeWork(i%threads, 500));
          }
           var result = await Task.WhenAll(tasks);
    }
