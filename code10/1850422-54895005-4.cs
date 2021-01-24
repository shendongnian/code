        public class TaskContainer
    {
        private ConcurrentBag<TaskInfo> Tasks;
        public TaskContainer(){
            Tasks = new ConcurrentBag<TaskInfo>();
        }
    //entry point
    //UPDATED
    public void StartAndMonitor(int processorCount)
    {
        
            for (int i = 0; i <= processorCount; i++)
            {
                Processor task = new Processor(ProcessorId = i);
                CreateProcessorTask(task);
            }
            this.IsRunning = true;
            MonitorTasks();
    }
    private void CreateProcessorTask(Processor processor)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        Task taskInstance = Task.Factory.StartNew(
            () => processor.Start(cancellationTokenSource.Token)
        );
        //bind status update event
        processor.ProcessorStatusUpdated += ReportProcessorProcess;
        Tasks.Add(new ProcessorInfo()
        {
            ProcessorId = processor.ProcessorId,
            Task = taskInstance,
            CancellationTokenSource = cancellationTokenSource
        });
    }
    //this method gets called once but the HeartbeatController gets an action as a param that it then
    //executes on a timer. I haven't included that but you get the idea
    
    //This method also checks for tasks that have stopped and restarts them if the manifest call says they should be running.
    //Will also start any new tasks included in the manifest and stop any that aren't included in the manifest.
    internal void MonitorTasks()
        {
            HeartbeatController.Beat(() =>
            {
                HeartBeatHappened?.Invoke(this, null);
                List<int> tasksToStart = new List<int>();
                //this is an api call or whatever drives your config that says what tasks must be running.
                var newManifest = this.GetManifest(Properties.Settings.Default.ResourceId);
                //task Removed Check - If a Processor is removed from the task pool, cancel it if running and remove it from the Tasks List.
                List<int> instanceIds = new List<int>();
                newManifest.Processors.ForEach(x => instanceIds.Add(x.ProcessorId));
                var removed = Tasks.Select(x => x.ProcessorId).ToList().Except(instanceIds).ToList();
                if (removed.Count() > 0)
                {
                    foreach (var extaskId in removed)
                    {
                        var task = Tasks.FirstOrDefault(x => x.ProcessorId == extaskId);
                        task.CancellationTokenSource?.Cancel();
                    }
                }
                foreach (var newtask in newManifest.Processors)
                {
                    var oldtask = Tasks.FirstOrDefault(x => x.ProcessorId == newtask.ProcessorId);
                    //Existing task check
                    if (oldtask != null && oldtask.Task != null)
                    {
                        if (!oldtask.Task.IsCanceled && (oldtask.Task.IsCompleted || oldtask.Task.IsFaulted))
                        {
                            var ex = oldtask.Task.Exception;
                            
                            tasksToStart.Add(oldtask.ProcessorId);
                            continue;
                        }
                    }
                    else //New task Check                       
                        tasksToStart.Add(newtask.ProcessorId);
                }
                foreach (var item in tasksToStart)
                {
                    var taskToRemove = Tasks.FirstOrDefault(x => x.ProcessorId == item);
                    if (taskToRemove != null)
                        Tasks.Remove(taskToRemove);
                    var task = newManifest.Processors.FirstOrDefault(x => x.ProcessorId == item);
                    if (task != null)
                    {
                        CreateProcessorTask(task);
                    }
                }
            });
        }
    }
    
    //UPDATED
    public class Processor{
    private int ProcessorId;
    private Subsriber<Message> subsriber;
    public Processor(int processorId) => ProcessorId = processorId;
    public void Start(CancellationToken token)
    {
        Subsriber<Message> subsriber = new Subsriber<Message>()
        {
            Interval = 1000
        };
        subsriber.Callback(Process, m => m != null);
    }
    private void Process()
    {
        //do work
    }
    }
    
