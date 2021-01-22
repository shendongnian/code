    private void DoSomeWork()
    {
        DataTable table = StoredProcedureParameters.Tables[0];
        var columns = table.Columns.Select(x => x.ColumnName).ToList();
        var workers = table.Rows.Select(row => new WorkerClass
                   (new ManualResetEvent(false), 
                    columns.ToDictionary(column => row[column]));
        foreach (WorkerClass worker in workers)
        {
            worker.Start();
        }
    }
    ...
    // This is now immutable, and contains the work that needs to be done for the
    // data it contains. (Only "shallow immutability" admittedly.)
    class WorkerClass
    {
        private readonly ManualResetEvent resetEvent;
        private readonly Dictionary<string, object> parameters;
        public WorkerClass(ManualResetEvent resetEvent, 
                           Dictionary<string, object> parameters)
        {
            this.resetEvent = resetEvent;
            this.parameters = parameters;
        }
        public void Start()
        {
            ThreadPool.QueueUserWorkItem(WorkerFunction);
        }
        private void WorkerFunction(object ignored)
        {
            // Whatever
        }
    }
