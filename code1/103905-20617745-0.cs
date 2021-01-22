    public interface IThingObserver
    {
        void Notify();  // can also pass in a parameter with event information
    }
    
    public class Thing
    {
        private readonly ICollection<IThingObserver> observers;
    
        public Thing()
        {
            observers = new List<IThingObserver>();
        }
    
        public void RegisterObserver(IThingObserver observer)
        {
            observers.Add(observer);
        }
    
        public void UnregisterObserver(IThingObserver observer)
        {
            observers.Remove(observer);
        }
    
        private void NotifyObservers()
        {
            foreach (IThingObserver observer in observers)
            {
                observer.Notify();
            }
        }
    
        public void DoIt()
        {
            Console.WriteLine("Doing it...");
            NotifyObservers();
        }
    }
    
    public class LoggingThingObserver : IThingObserver
    {
        public void Notify()
        {
            Log.Write("It is done.");
        }
    }
