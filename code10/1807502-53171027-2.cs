    class Foo
    {
        private Task runningTask {get;set;}
        public void StartTask()
        {
           runningTask = Task.Start( () => ....);
        }
        public async Task WaitTask()
        {
           await runningTask;
        }
     
        public bool IsRunning => runningTask != null && runningTask.Status......
