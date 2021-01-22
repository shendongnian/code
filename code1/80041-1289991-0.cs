    public void QueueWork(IWorkObject workObject)
    {
        Task.TaskFactory.StartNew(() =>
            {
                while (!workObject.Finished)
                {
                    int progress = workObject.DoSomeWork();
                    DoSomethingWithReportedProgress(workObject, progress);
                }
                WorkObjectIsFinished(workObject);
            });
    }
