    using System;
    using System.Reflection;
    
    namespace ConsoleApplication13
    {
        class Program
        {
            static void Main(string[] args)
            {
                A a = new A(); // the object *raising* the event
                EventInfo evt = a.GetType().GetEvent("MyEvent");
                B b = new B(); // the object *handling* the event (or null for static)
                MethodInfo handler = b.GetType().GetMethod("ConnectResponseReceived");
                Delegate del = Delegate.CreateDelegate(evt.EventHandlerType, b, handler);
                evt.AddEventHandler(a, del);
                a.OnMyEvent(); // test it
            }    
        }
        class A
        {
            public event EventHandler<CustomEventArgs> MyEvent;
            public void OnMyEvent() {
                var handler = MyEvent;
                if(handler != null) handler(this, new CustomEventArgs());
            }
        }
        class B
        {
            public void ConnectResponseReceived(object sender, EventArgs args) 
            {
                Console.WriteLine("got it");
            }
        }
        class CustomEventArgs : EventArgs { }
    }
