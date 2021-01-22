    // Overload EventArgs to send messageas back up
    public delegate void UpdateMethod(object sender, EventArgs e);
    
    public class WorkerClass
    {
        public event UpdateMethod UpdateMethod;
    }
    WorkerClass worker = new WorkerClass();
    
    worker.UpdateMethod += new UpdateMethod(worker_UpdateMethod);
