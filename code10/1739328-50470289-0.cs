    var myTasks = new List<Task>();
    Task allUpdateTasks;
    ...
    void Update () {
        myTasks.Add(
            Task.Factory.StartNew(() =>
            {
                threadOneString = ReadMessage(someClass.port);
            }));
    //Repeat for 11 more tasks
    // Create a single tasks that will hold all tasks above.
    allUpdateTasks = Task.WhenAll(myTasks);
    }
    
    void LateUpdate() {
        allUpdateTasks.Wait();
    ...
    }
