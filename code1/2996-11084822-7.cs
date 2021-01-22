    class Program
    {
        static void Main(string[] args)
        {
            EventWatcher<ISomeClassWithEvent> eventWatcher = new EventWatcher<ISomeClassWithEvent>();
            eventWatcher.WatchEvent(x => x.Changed += null);
            eventWatcher.WatchEvent(x => x.Changed -= null);
            Console.ReadLine();
        }
    }
