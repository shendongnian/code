    public delegate void OnTrue(String TestPassed);
    public event OnTrue OnTrueEvent = (item) => { }; // do nothing; not null
    public delegate void OnFalse(String TestPassed);
    public event OnFalse OnFalseEvent = (item) => { }; // do nothing; not null
...
    public void Do() {
      ...
      // No need to check for null here
      if (found) 
        OnFalseEvent(p);
      else
        OnTrueEvent(p); 
    }
