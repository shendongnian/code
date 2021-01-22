    public interface IRun
    {
        void Run();
    }
    public abstract class RunBase : IRun
    {
        [Description("Run Run Run")]
        [Version(1.0)]
        public abstract void Run() { }
    }
    public abstract class SoRunning : RunBase
    {
        public override void Run() {} 
    }
