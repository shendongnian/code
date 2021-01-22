    public void QueueWork(IWorkObject workObject)
    {
        ThreadPool.QueueUserWorkItem(() =>
            {
                while (!workObject.Finished)
                {
                    int progress = workObject.DoSomeWork();
                    DoSomethingWithReportedProgress(workObject, progress);
                }
                WorkObjectIsFinished(workObject);
            });
    }
