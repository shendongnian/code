    class Observer : IObserver
    {
      public Observer (Subject s)
      {
        s.Register (this);
      }
      void Notify (float value)
      {
        System.Diagnostics.Trace.WriteLine ("float value = " + value);
      }
      void Notify (int value)
      {
        System.Diagnostics.Trace.WriteLine ("int value = " + value);
      }
    }
    static void Main (string [] args)
    {
      Subject
        s = new Subject ();
      Observer
        o = new Observer (s);
      float
        v1 = 3.14f;
      int
        v2 = 42;
      System.Diagnostics.Trace.WriteLine ("sending float");
      s.NotifyObservers (v1);
      System.Diagnostics.Trace.WriteLine ("sending int");
      s.NotifyObservers (v2);
    }
