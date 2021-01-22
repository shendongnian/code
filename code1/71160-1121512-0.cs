    using System;
    using System.Reflection;
    class Test
    {
        public event EventHandler SomeEvent;
        public void OnSomeEvent()
        {
            if (SomeEvent != null) SomeEvent(this, EventArgs.Empty);
        }
        static void Main()
        {
            Test obj = new Test();
            EventInfo evt = obj.GetType().GetEvent("SomeEvent");
            MethodInfo handler = typeof(Test)
                .GetMethod("MyHandler");
            Delegate del = Delegate.CreateDelegate(
                evt.EventHandlerType, null, handler);
            evt.AddEventHandler(obj, del);
    
            obj.OnSomeEvent();
        }
    
        public static void MyHandler(object sender, EventArgs args)
        {
            Console.WriteLine("hi");
        }
    }
