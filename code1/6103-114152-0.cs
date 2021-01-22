    public class FileSystemEventSubscription : EventSubscription
    {
        private FileSystemWatcher fileSystemWatcher;
        public FileSystemEventSubscription(IComparable queueName, 
            Guid workflowInstanceId, FileSystemWatcher fileSystemWatcher) : base(queueName, workflowInstanceId)
        {
            this.fileSystemWatcher = fileSystemWatcher;
        }
