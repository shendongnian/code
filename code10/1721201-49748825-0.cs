    public delegate void OnTrue(String TestPassed);
    public event OnTrue OnTrueEvent = (item) => { }; // do nothing; nit null
    public delegate void OnFalse(String TestPassed);
    public event OnFalse OnFalseEvent = (item) => { }; // do nothing; nit null
...
    public void Do() {
      ...
      // No need to check for null here
      if (found) 
        OnFalse(p);
      else
        OnTrue(p); 
    }
