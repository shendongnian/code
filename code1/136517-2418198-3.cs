    public class Task
    {
        public int Variable1 { get; internal set; }
        public int Variable2 { get; internal set; }
    
        public void OnEnterTask(ITaskInitializer initializer)
        {
            initializer.Initialize(this);
        }
    }
    
    public interface ITaskInitializer
    {
        void Initialize(Task task);
    }
    public class SimpleTaskInitializer : ITaskInitializer
    {
        private int uGotIt = 10;
        public void Initialize(Task task)
        {
            task.Variable1 = uGotIt;
        }
    }
    public class ComplexTaskInitializer : ITaskInitializer
    {
        private int uGotIt = 10;
        private int multiplier = 10;
        public void Initialize(Task task)
        {
            task.Variable1 = uGotIt;
            task.Variable2 = uGotIt * multiplier;
            // etc - initialize task however required.
        }
    }
