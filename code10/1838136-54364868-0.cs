    namespace Rocket.Common
    {
        using System;
        using System.Threading;
        public class SharedProperties
        {
            public static bool snapEnabled = false;
            public static float snapValue = 0.25f;
            public static bool useAxisConstraints = true;
            private static event PushToGridEventHandler _pushToGridEvent;
            public static event PushToGridEventHandler PushToGridEvent
            {
                add
                {   
                    PushToGridEventHandler pushToGridEvent = _pushToGridEvent;
                    while (true)
                    {
                        PushToGridEventHandler a = pushToGridEvent;
                        PushToGridEventHandler handler3 = (PushToGridEventHandler)Delegate.Combine(a, value);
                        pushToGridEvent = Interlocked.CompareExchange(ref _pushToGridEvent, handler3, a);
                        if (ReferenceEquals(pushToGridEvent, a))
                        {
                            return;
                        }
                    }
                }
                remove
                {
                    PushToGridEventHandler pushToGridEvent = _pushToGridEvent;
                    while (true)
                    {
                        PushToGridEventHandler source = pushToGridEvent;
                        PushToGridEventHandler handler3 = (PushToGridEventHandler)Delegate.Remove(source, value);
                        pushToGridEvent = Interlocked.CompareExchange(ref _pushToGridEvent, handler3, source);
                        if (ReferenceEquals(pushToGridEvent, source))
                        {
                            return;
                        }
                    }
                }
            }
            public static void PushToGrid(float snapValue)
            {
                _pushToGridEvent?.Invoke(snapValue);
            }
        }
        public delegate void PushToGridEventHandler(float snapValue);
    }
