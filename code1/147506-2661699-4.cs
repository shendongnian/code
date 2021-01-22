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
        public void DoSomething()
        {
            var output = Decorate("Did something!");
            ConsoleWrapper.WriteLine(output);
        }
        protected abstract string Decorate(string input);
    }
    class WorldListener : Listener
    {
        protected override string Decorate(string input)
        {
            return string.Format("[World] {0}", input);
        }
    }
    class MasterListener : Listener
    {
        protected override string Decorate(string input)
        {
            return string.Format("[Master] {0}", input);
        }
    }
