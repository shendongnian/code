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
