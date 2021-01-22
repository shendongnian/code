    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Linq;
    namespace SimulatedThreadLocal
    {
        public sealed class Notifier
        {
            public void Register(Func<string> callback)
            {
                var id = Thread.CurrentThread.ManagedThreadId;
                lock (this._callbacks)
                {
                    List<Func<string>> list;
                    if (!this._callbacks.TryGetValue(id, out list))
                    {
                        this._callbacks[id] = list = new List<Func<string>>();
                    }
                    list.Add(callback);
                }
            }
            public void Execute()
            {
                var id = Thread.CurrentThread.ManagedThreadId;
                IEnumerable<Func<string>> threadCallbacks;
                string status;
                lock (this._callbacks)
                {
                    status = string.Format("Notifier has callbacks from {0} threads, total {1} callbacks{2}Executing on thread {3}",
                        this._callbacks.Count,
                        this._callbacks.SelectMany(d => d.Value).Count(),
                        Environment.NewLine,
                        Thread.CurrentThread.ManagedThreadId);
                    threadCallbacks = this._callbacks[id]; // we can use the original collection, as only this thread can add to it and we're not going to be adding right now
                }
                var b = new StringBuilder();
                foreach (var callback in threadCallbacks)
                {
                    b.AppendLine(callback());
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(status);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(b.ToString());
            }
            private readonly Dictionary<int, List<Func<string>>> _callbacks = new Dictionary<int, List<Func<string>>>();
        }
        public static class Program
        {
            public static void Main(string[] args)
            {
                try
                {
                    var notifier = new Notifier();
                    var syncMainThread = new ManualResetEvent(false);
                    var syncWorkerThread = new ManualResetEvent(false);
                    ThreadPool.QueueUserWorkItem(delegate // will create closure to see notifier and sync* events
                    {
                        notifier.Register(() => string.Format("Worker thread callback A (thread ID = {0})", Thread.CurrentThread.ManagedThreadId));
                        syncMainThread.Set();
                        syncWorkerThread.WaitOne(); // wait for main thread to execute notifications in its context
                        syncWorkerThread.Reset();
                        notifier.Execute();
                        notifier.Register(() => string.Format("Worker thread callback B (thread ID = {0})", Thread.CurrentThread.ManagedThreadId));
                        syncMainThread.Set();
                        syncWorkerThread.WaitOne(); // wait for main thread to execute notifications in its context
                        syncWorkerThread.Reset();
                        notifier.Execute();
                        syncMainThread.Set();
                    });
                    notifier.Register(() => string.Format("Main thread callback A (thread ID = {0})", Thread.CurrentThread.ManagedThreadId));
                    syncMainThread.WaitOne(); // wait for worker thread to add its notification
                    syncMainThread.Reset();
                    notifier.Execute();
                    syncWorkerThread.Set();
                    syncMainThread.WaitOne(); // wait for worker thread to execute notifications in its context
                    syncMainThread.Reset();
                    notifier.Register(() => string.Format("Main thread callback B (thread ID = {0})", Thread.CurrentThread.ManagedThreadId));
                    notifier.Execute();
                    syncWorkerThread.Set();
                    syncMainThread.WaitOne(); // wait for worker thread to execute notifications in its context
                    syncMainThread.Reset();
                }
                finally
                {
                    Console.ResetColor();
                }
            }
        }
    }
