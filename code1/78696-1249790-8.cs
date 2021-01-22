    namespace ObservablePattern
    {
        using System;
        using System.Collections.Generic;
    
        internal static class Program
        {
            private static void Main()
            {
                var observable = new Observable();
                var anotherObservable = new AnotherObservable();
    
                using (IObserver observer = new Observer(observable))
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
    
        internal sealed class Observable : IObservable
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
    
        internal sealed class AnotherObservable : IObservable
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
    
        internal interface IObserver : IDisposable
        {
            void Add(IObservable observable);
    
            void Remove(IObservable observable);
        }
    
        internal sealed class Observer : IObserver
        {
            private readonly Lazy<IList<IObservable>> observables =
                new Lazy<IList<IObservable>>(() => new List<IObservable>());
    
            public Observer()
            {
            }
    
            public Observer(IObservable observable) : this()
            {
                this.Add(observable);
            }
    
            public void Add(IObservable observable)
            {
                if (observable == null)
                {
                    return;
                }
    
                lock (this.observables)
                {
                    this.observables.Value.Add(observable);
                    observable.SomethingHappened += HandleEvent;
                }
            }
    
            public void Remove(IObservable observable)
            {
                if (observable == null)
                {
                    return;
                }
    
                lock (this.observables)
                {
                    observable.SomethingHappened -= HandleEvent;
                    this.observables.Value.Remove(observable);
                }
            }
    
            public void Dispose()
            {
                for (var i = this.observables.Value.Count - 1; i >= 0; i--)
                {
                    this.Remove(this.observables.Value[i]);
                }
            }
    
            private static void HandleEvent(object sender, EventArgs args)
            {
                Console.WriteLine("Something happened to " + sender);
            }
        }
    }
