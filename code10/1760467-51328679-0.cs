    public abstract class Plugin
    {
        public abstract int GetVersion();
    }
    
    public class FactoryPlugin<T> where T : Plugin, new()
    {
        public static int GetVersion()
        {
            return new T().GetVersion();
        }
    }
    
    public class Program
    {
        public Program()
        {
            if (FactoryPlugin<MyPlugin>.GetVersion() > 1)
            {
                
            }
        }
    }
