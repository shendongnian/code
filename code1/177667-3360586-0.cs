    public void RunWorker()
    {
        Thread newThread = new Thread(WorkerMethod);
        newThread.Start(ParameterObject);
    }
    public void WorkerMethod(object parameterObject)
    {
        // do your job!
    }
