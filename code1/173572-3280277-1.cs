    void OnClick_startTaskButton()
    {
         ProcessStuff(GetTask(), this);
    }
    
    private void ProcessStuff(Task sometask, Form progressform)
    {
        if (sometask.foo == "A")
            DoStuff();  //This one is SYNchronous
        else
        {
            ThirdPartyObject Q = new ThirdPartyObject();
            Q.ProgessChanged += delegate(object sender, ProgressChangedEventArgs e) 
                { TaskProgessChanged(sender, e); };
            Q.TaskCompleted += delegate(object sender, TaskResult result) 
                { TaskCompleted(sender, result); };
            Q.Execute("X", "Y", "Z");   //This one executes ASYNchronous
        }
    }
    
    void TaskProgessChanged(object sender, ProgressChangedEventArgs e)
    {
        if (InvokeRequired) Invoke(TaskProgessChanged, new object[] {sender, e} );
        else ShowProgress(e.ProgressPercentage);
    }
    
    void TaskCompleted(object sender, TaskResult result)
    {
        if (InvokeRequired) Invoke(TaskComplete, new object[] {sender, result} );
        else {
            MessageBox.Show("Task is completed with result :" + result.ToString());
        }
    }
