        foreach (var relatedObjectsTask in relatedObjectsTasks)
        {
            if (relatedObjectsTask.IsCancelled)
            {
                exceptionsDict.Add(
                    relatedObjectsTask.index,
                    new TaskCancelledException(relatedObjectsTask));
            }
            else if (relatedObjectsTask.IsFaulted)
            {
                exceptionsDict.TryAdd(relatedObjectsTask.index,  ex);
            }
            else
            {
                allSecondaries.Add(relatedObjectsTask.Result);
            }
        }
