    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dummy();
            var d2 = new Dummy();
            // use anonymouse methods without saving any references
            d.MyEvents += (sender, e) => { Console.WriteLine("One!"); };
            d.MyEvents += (sender, e) => { Console.WriteLine("Two!"); };
            // find the backing field and get its value
            var theType = d.GetType();
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var backingField = theType.GetField("MyEvents", bindingFlags);
            var backingDelegate = backingField.GetValue(d) as Delegate;
            var handlers = backingDelegate.GetInvocationList();
            // bind the handlers to the second instance
            foreach (var handler in handlers)
                d2.MyEvents += handler as EventHandler;
            // see if the handlers are fired
            d2.DoRaiseEvent();
            Console.ReadKey();
        }
    }
    class Dummy
    {
        public event EventHandler MyEvents;
        public void DoRaiseEvent() { MyEvents(this, new EventArgs()); }
    }
