    interface ITask
    {
        void Execute(ExcecutionContext context);
    }
    
    [TaskName("Send Emails")
    class SendEmailsTask : ITask
    {
        public void Execute(ExcecutionContext context) 
        {
            // Send emails. ExecutionContext might contain a dictionary of 
            // key/value pairs for additional arguments needed for your task. 
        }
    }
    
    class TaskExecuter 
    {
        public void ExecuteTask(string name) 
        {
            // "name" comes from the database entry
            var types = Assembly.GetExecutingAssembly().GetTypes();    
            foreach (var type in types)
            {
                // Check type.GetCustomAttributes for the TaskAttribute, then check the name
            }
        }
    }
