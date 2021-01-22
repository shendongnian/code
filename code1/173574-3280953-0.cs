    private Queue<Task> myqueue;
    private void Main() {
        //Do stuff
        //Fill queue
        ProcessQueue();        
    }
    private void ProcessQueue() {
        if (myqeue.count>1)
            ProcessStuff(myqeue.Dequeue());
        else
            MessageBox.Show("Done!");
    }
    private void ProcessStuff(Task sometask, Form progressform)
    {
        if (sometask.foo == "A") {
            DoStuff();  //This one is SYNchronous
            ProcessQueue();
        }
        else
        {
            ThirdPartyObject Q = new ThirdPartyObject();
            Q.ProgessChanged += delegate(object sender, ProgressChangedEventArgs e) {
                progressform.ShowProgress(e.ProgressPercentage);
            };
            Q.TaskCompleted += delegate(object sender, TaskResult result) {
                ProcessQueue();
            };
            Q.Execute("X", "Y", "Z");   //This one executes ASYNchronous
        }
    }
