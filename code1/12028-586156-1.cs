    using System;
    using System.Reflection;
    static class Program {
      private class Sub {
        public event EventHandler<EventArgs> SomethingHappening;
      }
      internal static void Raise<TEventArgs>(this object source, string eventName, TEventArgs eventArgs) where TEventArgs : EventArgs
      {
        var eventDelegate = (MulticastDelegate)source.GetType().GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(source);
        if (eventDelegate != null)
        {
          foreach (var handler in eventDelegate.GetInvocationList())
          {
            handler.Method.Invoke(handler.Target, new object[] { source, eventArgs });
          }
        }
      }
      public static void Main()
      {
        var p = new Sub();
        p.Raise("SomethingHappening", EventArgs.Empty);
        p.SomethingHappening += (o, e) => Console.WriteLine("Foo!");
        p.Raise("SomethingHappening", EventArgs.Empty);
        p.SomethingHappening += (o, e) => Console.WriteLine("Bar!");
        p.Raise("SomethingHappening", EventArgs.Empty);
        Console.ReadLine();
      }
    }
