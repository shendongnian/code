    public class Task
    {
        private int accessMe;
    
        public void OnEnterTask(TaskArgument args)
        {
            accessMe = args.AccessMe;
        }
    }
    
    public interface ITaskArgument
    {
        int AccessMe { get; }
    }
    public class ComplexTaskArgument : ITaskArgument
    {
        private int uGotIt = 10;
        private int multiplier = 10;
        public int AccessMe
        {
            get { return uGotIt * multiplier; }
        }
    }
    public class SimpleTaskArgument : ITaskArgument
    {
        private int uGotIt = 10;
        public int AccessMe
        {
            get { return uGotIt; }
        }
    }
