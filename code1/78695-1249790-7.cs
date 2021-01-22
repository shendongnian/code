    namespace ObservablePattern
    {
        using System;
        using System.Collections.Generic;
        using System.Threading;
    
        internal static class Program
        {
            private static void Main()
            {
                var observable = new Observable();
                var anotherObservable = new AnotherObservable();
    
                using (var observer = new Observer(observable))
                {
                    observable.DoSomething();
                    observer.Add(anotherObservable);
                    anotherObservable.DoSomething();
                }
    
                Console.ReadLine();
            }
        }
    
        internal interface IObservable
        {
            event EventHandler SomethingHappened;
        }
    
        internal class Observable : IObservable
        {
            public event EventHandler SomethingHappened;
    
            public void DoSomething()
            {
                var handler = this.SomethingHappened;
    
                Console.WriteLine("About to do something.");
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    
        internal class AnotherObservable : IObservable
        {
            public event EventHandler SomethingHappened;
    
            public void DoSomething()
            {
                var handler = this.SomethingHappened;
    
                Console.WriteLine("About to do something different.");
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    
        internal class Observer : IDisposable
        {
            private static readonly object listLocker = new object();
    
            private static readonly ReaderWriterLockSlim listItemLocker = new ReaderWriterLockSlim();
    
            private ICollection<IObservable> observables;
    
            private EventHandler eventHandler;
    
            public Observer()
            {
            }
    
            public Observer(IObservable observable)
            {
                if (observable == null)
                {
                    return;
                }
    
                this.observables = new List<IObservable> { observable };
    
                this.eventHandler = HandleEvent;
                observable.SomethingHappened += this.eventHandler;
            }
    
            public void Add(IObservable observable)
            {
                if (observable == null)
                {
                    return;
                }
    
                if (this.observables == null)
                {
                    lock (listLocker)
                    {
                        if (this.observables == null)
                        {
                            var newObservables = new List<IObservable>();
    
                            Thread.MemoryBarrier();
                            this.observables = newObservables;
                            this.eventHandler = HandleEvent;
                        }
                    }
                }
    
                listItemLocker.EnterWriteLock();
                try
                {
                    this.observables.Add(observable);
                    observable.SomethingHappened += this.eventHandler;
                }
                finally
                {
                    listItemLocker.ExitWriteLock();
                }
            }
    
            public void Remove(IObservable observable)
            {
                if ((observable == null) || (this.observables == null))
                {
                    return;
                }
    
                listItemLocker.EnterWriteLock();
                try
                {
                    this.observables.Remove(observable);
                    observable.SomethingHappened -= this.eventHandler;
                }
                finally
                {
                    listItemLocker.ExitWriteLock();
                }
            }
    
            public void Dispose()
            {
                if (this.observables != null)
                {
                    foreach (var observable in this.observables)
                    {
                        observable.SomethingHappened -= this.eventHandler;
                    }
                }
    
                GC.SuppressFinalize(this);
            }
    
            private static void HandleEvent(object sender, EventArgs args)
            {
                Console.WriteLine("Something happened to " + sender);
            }
        }
    }
