    public static class EventFirer
    {
        public static void SafeFire<TEventArgs>(this EventHandler<TEventArgs> theEvent, object obj, TEventArgs theEventArgs)
            where TEventArgs : EventArgs
        {
            if (theEvent != null)
                theEvent(obj, theEventArgs);
        }
    }
    class MyEventArgs : EventArgs
    {
        // Blah, blah, blah...
    }
    class UseSafeEventFirer
    {
        event EventHandler<MyEventArgs> MyEvent;
        void DemoSafeFire()
        {
            MyEvent.SafeFire(this, new MyEventArgs());
        }
        static void Main(string[] args)
        {
            var x = new UseSafeEventFirer();
            Console.WriteLine("Null:");
            x.DemoSafeFire();
            Console.WriteLine();
            x.MyEvent += delegate { Console.WriteLine("Hello, World!"); };
            Console.WriteLine("Not null:");
            x.DemoSafeFire();
        }
    }
