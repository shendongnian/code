    public void processStuff()
    {
        Status returnStatus 
        SortedList<int, TaskBase> list = new SortedList<int, TaskBase>();
        // code or method call to load task list, sorted in order of execution.
        try
        {
            foreach(KeyValuePair<int, TaskBase> task in list)
            {
                Status returnStatus task.Value.ExecuteTask();
                if(returnStatus != Status.Success)
                {
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            log(ex);
            returnStatus = Status.Error;
        }
        finally
        {
            //some necessary cleanup
        }
        
        return returnStatus;
    }
