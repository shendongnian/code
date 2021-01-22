    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Threading;
    
    namespace ManagedHelpers.Threads
    {
        public class STASynchronizationContext : SynchronizationContext, IDisposable
        {
            private readonly Dispatcher dispatcher;
            private object dispObj;
            private readonly Thread mainThread;
    
            public STASynchronizationContext()
            {
                mainThread = new Thread(MainThread) { Name = "STASynchronizationContextMainThread", IsBackground = false };
                mainThread.SetApartmentState(ApartmentState.STA);
                mainThread.Start();
    
                //wait to get the main thread's dispatcher
                while (Thread.VolatileRead(ref dispObj) == null)
                    Thread.Yield();
    
                dispatcher = dispObj as Dispatcher;
            }
    
            public override void Post(SendOrPostCallback d, object state)
            {
                dispatcher.BeginInvoke(d, new object[] { state });
            }
    
            public override void Send(SendOrPostCallback d, object state)
            {
                dispatcher.Invoke(d, new object[] { state });
            }
    
            private void MainThread(object param)
            {
                Thread.VolatileWrite(ref dispObj, Dispatcher.CurrentDispatcher);
                Console.WriteLine("Main Thread is setup ! Id = {0}", Thread.CurrentThread.ManagedThreadId);
                Dispatcher.Run();
            }
    
            public void Dispose()
            {
                if (!dispatcher.HasShutdownStarted && !dispatcher.HasShutdownFinished)
                    dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
    
                GC.SuppressFinalize(this);
            }
    
            ~STASynchronizationContext()
            {
                Dispose();
            }
        }
    }
