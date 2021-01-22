    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    namespace TemporalThingy
    {
        class Program
        {
            static void Main(string[] args)
            {
                Action action = () => Thread.Sleep(10000);
                DoSomething(action, 5000);
                Console.ReadKey();
            }
            static void DoSomething(Action action, int timeout)
            {
                EventWaitHandle waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
                AsyncCallback callback = ar => waitHandle.Set();
                action.BeginInvoke(callback, null);
                if (!waitHandle.WaitOne(timeout))
                    throw new Exception("Failed to complete in the timeout specified.");
            }
        }
    }
