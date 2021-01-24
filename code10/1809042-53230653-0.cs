    public async Task<IList<TimeEntry>> CallSomething(DateTime startDate, DateTime endDate)
    {
        var qry = string.Format("timeStart >= [{0}] and timeEnd <= [{1}]", startDate, endDate); //For example
        const threadCount = 4;
        var isComplete = new ManualResetEvent();
        var page = 0;
        var results = new ConcurrentBag<TimeEntry>();
        var thread = new Task[threadCount];
        for(var i = 0; i < threadCount; ++i)
        {
            thread[i] = Task.Run(
                async () =>
                {
                    while(!isComplete.WaitOne(TimeSpan.Zero))
                    {
                        var localPage = Interlocked.Increment(ref page);
                        var newItems = await api
                            .GetEntries(qry, "id desc", maxPageSize, localPage)
                            .GetResultsAsync<List<TimeEntry>>()
                            .ConfigureAwait(false);
                        if (!newItems.Any())
                        {
                            isComplete.Set();
                        }
                        else
                        {
                            foreach (var item in newItems)
                            {
                                results.Add(item);
                            }
                        }
                    }
                })
            )
        }
        await Task.WhenAll(thread).ConfigureAwait(false);
        return results.OrderByDescending(f => f.Id).ToList();
    }
