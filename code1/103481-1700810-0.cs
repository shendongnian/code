    public abstract class TaskDefinitionBase : ITaskDefinition
    {
        private string name_ = null;
        public abstract ITask CreateTask(TaskId id);
    
        public string Name
        {
            get
            {
                return name_;
            }
            set
            {
                name_ = value
            }
        }
    
        public bool HasName
        {
            get
            {
                return name_ != null;
            }
        }
    }
