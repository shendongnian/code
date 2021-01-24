    public static async Task<int> Work()
    {
        var id = await CreateIdInDB() // async create record in DB
    
        // run background task, don't wait when it finishes
        Task.Run(async () => {
            List<Task> worker = new List<Task>();
            foreach (var i in listOfData)
            {
                worker.Add(ProcessSingle(x));
            }
            await Task.WhenAll(worker);
        });
    
        // return created id immediately
        return id;
    }
