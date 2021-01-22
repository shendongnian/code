    private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
       if (TaskQueue.Count > 0)
       {
          TaskQueue[0].Execute();
       }
    }
    private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Task t = TaskQueue[0];
        lock (TaskQueue)
        {
            TaskQueue.Remove(t);
        }
        if (TaskQueue.Count > 0 && !BackgroundWorker.IsBusy)
        {
            BackgroundWorker.RunWorkerAsync();
        }
    }
    public void Enqueue(Task t)
    {
       lock (TaskQueue)
       {
          TaskQueue.Add(t);
       }
       if (!BackgroundWorker.IsBusy)
       {
          BackgroundWorker.RunWorkerAsync();
       }
    }
