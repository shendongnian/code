    public class EventWatcher<T>
    {
        public void WatchEvent(Action<T> eventToWatch)
        {
            CustomProxy<T> proxy = new CustomProxy<T>(InvocationType.Event);
            T tester = (T)proxy.GetTransparentProxy();
            eventToWatch(tester);
            Console.WriteLine(string.Format("Event to watch = {0}", proxy.Invocations.First()));
        }
    }
