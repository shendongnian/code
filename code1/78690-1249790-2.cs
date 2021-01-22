    namespace ObservablePattern
    {
        using System;
        using System.Collections.Generic;
    
        internal static class Program
        {
            private static void Main()
            {
                Observable observable = new Observable();
                AnotherObservable anotherObservable = new AnotherObservable();
    
                using (Observer observer = new Observer(observable))
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
            private event EventHandler somethingHappened;
    
            public event EventHandler SomethingHappened
            {
                add
                {
                    this.somethingHappened += value;
                }
    
                remove
                {
                    this.somethingHappened -= value;
                }
            }
    
            public void DoSomething()
            {
                EventHandler handler = this.somethingHappened;
    
                Console.WriteLine("About to do something.");
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    
        internal class AnotherObservable : IObservable
        {
            private event EventHandler somethingHappened;
    
            public event EventHandler SomethingHappened
            {
                add
                {
                    this.somethingHappened += value;
                }
    
                remove
                {
                    this.somethingHappened -= value;
                }
            }
    
            public void DoSomething()
            {
                EventHandler handler = this.somethingHappened;
    
                Console.WriteLine("About to do something different.");
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    
        internal class Observer : IDisposable
        {
            private ICollection<IObservable> observables;
            private EventHandler eventHandler;
    
            public Observer()
            {
            }
    
            public Observer(IObservable observable)
            {
                if (observable != null)
                {
                    this.observables = new List<IObservable>
                    {
                        observable
                    };
    
                    this.eventHandler = new EventHandler(this.HandleEvent);
                    observable.SomethingHappened += this.eventHandler;
                }
            }
    
            public void Add(IObservable observable)
            {
                if (observable != null)
                {
                    if (this.observables == null)
                    {
                        this.observables = new List<IObservable>
                        {
                            observable
                        };
    
                        this.eventHandler = new EventHandler(this.HandleEvent);
                    }
                    else
                    {
                        this.observables.Add(observable);
                    }
    
                    observable.SomethingHappened += this.eventHandler;
                }
            }
    
            public void Remove(IObservable observable)
            {
                if (observable != null)
                {
                    if (this.observables != null)
                    {
                        this.observables.Remove(observable);
                        observable.SomethingHappened -= this.eventHandler;
                    }
                }
            }
            #region IDisposable Members
    
            public void Dispose()
            {
                if (this.observables != null)
                {
                    foreach (IObservable observable in this.observables)
                    {
                        observable.SomethingHappened -= this.eventHandler;
                    }
                }
    
                GC.SuppressFinalize(this);
            }
    
            #endregion
    
            private void HandleEvent(object sender, EventArgs args)
            {
                Console.WriteLine("Something happened to " + sender);
            }
        }
    }
