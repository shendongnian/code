    public void IncreaseCounter()
    {
      int oldCounter = this.Counter;
      try {
          this.Counter = this.Counter + 1;
          OnCounterChanged(EventArgs.Empty);
      } catch {
          this.Counter = oldCounter;
          throw;
      }
    }
