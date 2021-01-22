    public class Observer
    {
        // Constructor with an instance name.
        public Observer(String name)
        {
            this.Name = name;
        }
        public String Name { get; private set; }
        // The method to be registered as event handler.
        public void NotifierValueChanged(Notifier sender, Int32 oldValue, Int32 newValue)
        {
            Console.WriteLine(String.Format("{0}: The value of {1} changed from {2} to {3}.", this.Name, sender.Name, oldValue, newValue));
        }
    }
