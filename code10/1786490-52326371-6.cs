    public static async Task<int> Work()
    {
        var id = await CreateIdInDB() // async create record in DB
        
        // run background task, don't wait when it finishes
        Task.Run(async () => {
            List<Task> worker = new List<Task>();
            //To limit the number of Task started.
            var throttler = new SemaphoreSlim(initialCount: 20);
            foreach (var i in listOfData)
            {
                await throttler.WaitAsync();
                worker.Add(Task.Run(async () =>
                {
                    await ProcessSingle(x);
                    throttler.Release();
                }
                ));
            }
            await Task.WhenAll(worker);
        });
    
        // return created id immediately
        return id;
    }
