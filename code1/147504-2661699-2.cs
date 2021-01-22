    static class Program
    {
        static void Main(string[] args)
        {
            Listener listener = new WorldListener();
            listener.DoSomething();
        }
    }
    abstract class Listener
    {
        public abstract void DoSomething();
    }
    class WorldListener : Listener
    {
        public override void DoSomething()
        {
            ConsoleWrapper.WriteLine("[World] Did something!");
        }
    }
    class MasterListener : Listener
    {
        public override void DoSomething()
        {
            ConsoleWrapper.WriteLine("[Master] Did something!");
        }
    }
