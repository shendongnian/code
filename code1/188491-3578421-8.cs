    abstract class Job
    {
        public abstract string ExePath
        {
            get;
        }
        public void Execute(string[] args)
        {
            Console.WriteLine("Executing {0}", this.ExePath);
        }
    }
    abstract class Job<T> where T : Job<T>
    {
        public override string ExePath
        {
            get { return JobInfo<T>.ExePath; }
        }
    }
    class ConcreteJob1 : Job<ConcreteJob1> { }
    class ConcreteJob2 : Job<ConcreteJob1> { }
    static class JobInfo<T> where T : Job<T>
    {
        public static string ExePath;
    }
    static class JobInfoInitializer
    {
        public static void InitializeExePaths()
        {
            JobInfo<ConcreteJob1>.ExePath = "calc.exe";
            JobInfo<ConcreteJob2>.ExePath = "notepad.exe";
        }
    }
