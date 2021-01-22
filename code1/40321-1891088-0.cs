    using System;
    using System.Threading;
    namespace EventsMultithreadingTest
    {
        public class Program
        {
            private static Action<object> _delegate = new Action<object>(Program_Event);
            public static event Action<object> Event;
            public static void Main(string[] args)
            {
                Thread thread = new Thread(delegate()
                    {
                        while (true)
                        {
                            Action<object> ev = Event;
                            if (ev != null)
                            {
                                ev.Invoke(null);
                            }
                        }
                    });
                thread.Start();
                while (true)
                {
                    Event += _delegate;
                    Event -= _delegate;
                }
            }
            static void Program_Event(object obj)
            {
                object.Equals(null, null);
            }
        }
    }
