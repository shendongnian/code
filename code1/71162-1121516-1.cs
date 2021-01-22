    using System;
    using System.Reflection;
    class EventPublisher
    {
        public event EventHandler TestEvent;
        public void RaiseEvent()
        {
            TestEvent(this, EventArgs.Empty);
        }
    }
    class Test
    {
        void HandleEvent(object sender, EventArgs e)
        {
            Console.WriteLine("HandleEvent called");
        }
        static void Main()
        {
            // Find the handler method
            Test test = new Test();
            EventPublisher publisher = new EventPublisher();
            MethodInfo method = typeof(Test).GetMethod
                ("HandleEvent", BindingFlags.NonPublic | BindingFlags.Instance);
            // Subscribe to the event
            EventInfo eventInfo = typeof(EventPublisher).GetEvent("TestEvent");
            Type type = eventInfo.EventHandlerType;
            Delegate handler = Delegate.CreateDelegate(type, test, method);
            // Raise the event
            eventInfo.AddEventHandler(publisher, handler);
            publisher.RaiseEvent();
        }
    }
