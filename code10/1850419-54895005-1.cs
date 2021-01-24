    public class TaskContainer
    {
    private ConcurrentBag<TaskInfo> Tasks;
    public TaskContainer(){
        Tasks = new ConcurrentBag<TaskInfo>();
    }
    public void StartListeningForMessages()
    {
    
        Subsriber<Message> subsriber = new Subsriber<Message>()
        {
            Interval = 1000
        };
        subsriber.Callback(Process, m => m != null);
        
        }
    }
    //Each time Process is called it starts a new task which gets added to the Tasks list. 
    //Cancellation tokens are only really necessary if you are making the task do looping work or something like in this example with the while(true),
    //If you're not doing that then you can probably do without it.
    public void Process(Message message)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        //If you're wanting to have a certain max number of tasks running at any one time you'd have to implement some kind of queueing logic to stop from creating 
        //tasks without control like could happen here
        Task task = Task.Factory.StartNew(() => ProcessMessage(cancellationTokenSource.CancellationToken));
        //I don't know if you actually need this but
        //By adding your tasks to a collection you can now montior them, see how many are running, remove them when completed etc, in a method called on another thread from within this class, 
        //by using a Timer to call a method that does this.
        //But now you have to be careful though as you might need to use a ConcurrentBag or something if that montoring method is not the only thread working with that 
        //list (since you might have the Process method adding items of the Task list for instance).
        Tasks.TryAdd(new TaskInfo()
            {
                Id = item.Id,
                Task = task,
                CancellationTokenSource = cancellationTokenSource
            });
    }
    public void ProcessMessage(CancellationToken token)
    {
            while (true) //optional for what your work is doing, if it's just a straight run through process you could remove all this and just call dowork or whatever.
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                
                DoWork();
                
            }
    }
    //this method can be called by a timer somewhere and you can use it to work with 
    //the Tasks collection to remove completed tasks, and things like that, or check for 
    //updates in configuration that affect what tasks you're running if you wanted 
    //external control over long running tasks or just cleaning up the Tasks collection //where tasks
     //have completed (removing them from the collection).
    public void Monitor()
    {
    }
     }
    
