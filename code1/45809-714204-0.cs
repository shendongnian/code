    using System;
    class Foo
    {
        public event EventHandler SomeEvent;
        public Foo()
        {
            SomeEvent += SecretHandler; // a bad idea, anyway
                                        //(self-subscribed events....)
        }
        protected virtual void OnSomeEvent()
        {
            EventHandler handler = SomeEvent;
            if (handler != null) handler(this, EventArgs.Empty);
        }
        private void SecretHandler(object sender, EventArgs args)
        {
            Console.WriteLine("suscribed");
        }
    }
    class Bar : Foo
    {
        public Bar()
        {
            /*
            MethodInfo method = typeof(Foo).GetMethod("SecretHandler",
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandler handler = (EventHandler)Delegate.CreateDelegate(
                typeof(EventHandler), this, method);
            SomeEvent -= handler;
             */
        }
        public void Test()
        {
            OnSomeEvent();
        }
    }
    static class Program
    {
        static void Main()
        {
            Bar bar = new Bar();
            bar.Test();
        }
    }
