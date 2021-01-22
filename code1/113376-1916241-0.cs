    class TestHarness
    {
        static void Main(string[] args)
        {
            var raiser = new SomeClass();
            // Emulate some event listeners
            raiser.SomeEvent += (sender, e) => { Console.WriteLine("   Received event"); };
            raiser.SomeEvent += (sender, e) =>
            {
                // Bad listener!
                Console.WriteLine("   Blocking event");
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("   Finished blocking event");
            };
            // Listener who throws an exception
            raiser.SomeEvent += (sender, e) =>
            {
                Console.WriteLine("   Received event, time to die!");
                throw new Exception();
            };
            // Raise the event, see the effects
            raiser.DoSomething();
            Console.ReadLine();
        }
    }
    class SomeClass
    {
        public event EventHandler SomeEvent;
        public void DoSomething()
        {
            OnSomeEvent();
        }
        private void OnSomeEvent()
        {
            if (SomeEvent != null)
            {
                var eventListeners = SomeEvent.GetInvocationList();
                Console.WriteLine("Raising Event");
                for (int index = 0; index < eventListeners.Count(); index++)
                {
                    var methodToInvoke = (EventHandler)eventListeners[index];
                    methodToInvoke.BeginInvoke(this, EventArgs.Empty, EndAsyncEvent, null);
                }
                Console.WriteLine("Done Raising Event");
            }
        }
        private void EndAsyncEvent(IAsyncResult iar)
        {
            var ar = (System.Runtime.Remoting.Messaging.AsyncResult)iar;
            var invokedMethod = (EventHandler)ar.AsyncDelegate;
            try
            {
                invokedMethod.EndInvoke(iar);
            }
            catch
            {
                // Handle any exceptions that were thrown by the invoked method
                Console.WriteLine("An event listener went kaboom!");
            }
        }
    }
