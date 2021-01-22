    public static class BackgroundWorkerHelper
    {
    public static void RunInBackground(Action doWorkAction, Action completedAction, CultureInfo cultureInfo)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += (_, args) =>
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
                doWorkAction.Invoke();
            };
            worker.RunWorkerCompleted += (_, args) =>
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
                completedAction.Invoke();
            };
            worker.RunWorkerAsync();
        }
    }
