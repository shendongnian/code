    public void RunWorker()
    {
        Thread newThread = new Thread(WorkerMethod);
        newThread.Start(new Parameter());
    }
    public void WorkerMethod(object parameterObj)
    {
        var parameter = (Parameter)parameterObj;
        // do your job!
    }
