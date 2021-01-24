      var queryService = filters.Select(x => sClient.GetAllAsync()).ToArray();
            try
            {
                // Wait for all the tasks to finish.
                Task.WaitAll(queryService);
            }
            catch (AggregateException e)
            {
                //At least one of the Task instances was canceled.
                //If a task was canceled, the AggregateException contains an OperationCanceledException in its InnerExceptions collection.
            }
