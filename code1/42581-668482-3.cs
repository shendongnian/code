    public abstract partial class OperatingWindowBase : Form
    {
        public void Execute()
        {
            // call this.OnExecute(); asyncronously so you can animate
        }
        protected abstract void OnExecute();
    }
    
    public class OperatingWindowFunc<T> : OperatingWindowBase
    {
        Func<T> operation;
        public T Result { get; private set; }
        public OperatingWindowFunc<T>(Func<T> operation)
        {
            this.operation = operation;
        }
        protected override OnExecute()
        {
            this.Result = operation();
        }
    }
    
    public class OperatingWindowAction
    {
        Action operation;
        public OperatingWindow(Action operation)
        {
            this.operation = operation;
        }
        protected override OnExecute()
        {
            operation();
        }
    }
