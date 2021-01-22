    public interface ITaskArgument
    {
        void Initialize(Task task);
    }
    public abstract class TaskArgument : ITaskArgument
    {
        protected int _value;
        public class TaskArgument(int value)
        {
            _value = value;
        }
        public abstract void Initialize(Task task);
    }
    public class SimpleTaskArgument : TaskArgument, ITaskArgument
    {
        public SimpleTaskArgument(int value)
           : base (value)
        {
        }
    
        public override void Initialize(Task task)
        {
            task.AccessMe = value;
        }
    }
    public class ComplexTaskArgument : TaskArgument, ITaskArgument
    {
        private int multiplier;
        public ComplexTaskArgument(int value, int multiplier)
           : base (value)
        {
        }
        public override void Initialize(Task task)
        {
            task.AccessMe = value * multiplier;
        }
    }
    public class Task
    {
        public Task()
        {
        }
        public int AccessMe { get; set; }
        public void OnEnterTask(ITaskArgument args)
        {                         
            args.Initialize(this);                         
        }  
    }
