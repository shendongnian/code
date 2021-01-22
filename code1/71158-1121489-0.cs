    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            var eventInfo = p.GetType().GetEvent("TestEvent");
            var methodInfo = p.GetType().GetMethod("TestMethod");
            Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, p, methodInfo);
            eventInfo.AddEventHandler(p, handler);
            p.Test();
        }
        public event Func<string> TestEvent;
        public string TestMethod()
        {
            return "Hello World";
        }
        public void Test()
        {
            if (TestEvent != null)
            {
                Console.WriteLine(TestEvent());
            }
        }
    }
