    public class Task
    {
        private int accessMe;
    
        protected override void OnEnterTask(TaskArgument args)
        {
            accessMe = args.AccessMe;
        }
            
    }
    
    public interface TaskArgument
    {
        int AccessMe { get; }
    }
