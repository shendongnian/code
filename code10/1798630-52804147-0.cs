    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            Consumer consumer = new Consumer(invoker);
            invoker.RunEvents();
        }
    }
    class Invoker
    {
        public delegate void SomeEventHandler();
        public event SomeEventHandler SomeEvent;
        public void RunEvents()
        {
            while (true)
                SomeEvent.Invoke();
        }
    }
    class Consumer
    {
        public Consumer(Invoker invoker)
        {
            invoker.SomeEvent += HandleSomeEvent;
        }
        private void HandleSomeEvent()
        {
            Console.WriteLine("Handling event");
            Thread.Sleep(500);
        }
    }
