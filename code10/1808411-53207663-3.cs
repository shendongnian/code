    //Hold active tasks
    Task[] _tasks;
    private void WorkerMethod1(CancellationToken token)
    {
        //If cancellation isn't requested
        while(!token.IsCancellationRequested)
        {
            //Loop one more time
        }
    }
    CancellationTokenSource _cts;
    private void OnLoad(...)
    {
        //Fire the tasks
        StartTasks();
    }
    private void StartTasks()
    {
       _cts=new CancellationTokenSource();
      //Start each method passing a CancellationToken
       _tasks=new[]{
                     Task.Run(()=>WorkerMethod1(_cts.Token)),
                     Task.Run(()=>WorkerMethod2(_cts.Token)),
                      ...
                   };
       //Enable the Cancel button
       Cancel.Enabled=true;
    }
    private async void Cancel_Clicked(object sender,EventArgs args)
    {
        if (_cts!=null)
        {
           //Signal a cancellation
            _cts.Cancel();
           //Asynchronously wait for all tasks to finish
            await Task.WhenAll(_tasks);
            _cts=null;           
        }
        //Disable the button
        Cancel.Enabled=false;
    }
