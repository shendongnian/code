    private void ProcessStuff(Task sometask, Form progressform)
    {
        ProcessStuff(sometask, progressform, true);
    }
    
    private void ProcessStuff(Task sometask, Form progressform, bool isNewTask)
    {
        if (isNewTask)
            if (sometask.foo == "A")
                DoStuff();  //This one is SYNchronous
            else
            {
                ThirdPartyObject Q = new ThirdPartyObject();
                Q.ProgessChanged += delegate(object sender, ProgressChangedEventArgs e) {
                    progressform.ShowProgress(e.ProgressPercentage);
                };
                Q.TaskCompleted += delegate(object sender, TaskResult result) 
                    { ProcessStuff(sometask, this, false); };
                Q.Execute("X", "Y", "Z");   //This one executes ASYNchronous
            }
        else
        {
            if (InvokeRequired) Invoke(TaskComplete, new object[] {sender, result, isNewTask} );
            else {
                //Task is completed
                MessageBox.Show("Task is completed");
            }
        }
    }
