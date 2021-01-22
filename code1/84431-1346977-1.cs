    public abstract class Activity
        {
            public virtual Guid Id { get; set; }
            public virtual ActivityExecutionResult ExecutionResult { get; private set; }
            
            public virtual ActivityExecutionStatus ExecutionStatus {get;private set;}
    
            public abstract ActivityExecutionStatus Execute();
    
            public virtual string ActivityName { get; private set; }
    
            public virtual IDictionary<string, string> ActivityParameters { get; private set; }
    
            public virtual ActivityType ActivityType { get; private set; }
        }
