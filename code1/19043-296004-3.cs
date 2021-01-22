    interface IObserver
    {
    }
    class Subject
    {
      public Subject ()
      {
        m_observers = new List<IObserver> ();
      }
      public void Register (IObserver o)
      {
        m_observers.Add (o);
      }
      List<IObserver>
        m_observers;
    }
