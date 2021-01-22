    public class Example
    {
       public int Counter { get; private set; }
       public void IncreaseCounter()
       {
          OnCounterChanging(EventArgs.Empty);
          this.Counter = this.Counter + 1;
          OnCounterChanged(EventArgs.Empty);
       }
       protected virtual void OnCounterChanged(EventArgs args)
       {
          if (CounterChanged != null)
             CounterChanged(this, args);
       }
       protected virtual void OnCounterChanging(EventArgs args)
       {
          if (CounterChanging != null)
             CounterChanging(this, args);
       }
       public event EventHandler<EventArgs> CounterChanging;
       public event EventHandler<EventArgs> CounterChanged;
    }
