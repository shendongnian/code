    public static class Monitor
    {
        private static Dictionary<IMonitorHandle, Func<string>> monitoredObjects;
        public static void Initialize()
        {
            monitoredObjects = new Dictionary<IMonitorHandle, Func<string>>();
        }
        public static IMonitorHandle Watch(Func<string> o)
        {
            var handle = new MonitorHandle(o);
            monitoredObjects.Add(handle, o);
            return handle;
        }
        public static void Unwatch(IMonitorHandle handle)
        {
            monitoredObjects.Remove(handle);
        }
        public static void Draw(RenderWindow app)
        {
            //Not actual code, I actually draw this in game
            foreach (object o in monitoredObjects.Values)
               Console.WriteLine(o()); // Execute to get value...
        }
    }
