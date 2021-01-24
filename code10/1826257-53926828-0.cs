    [Conditional("DEBUG")]
    private void UseThing(parameters here)
    {
       // use your thing with the parameters
    }
    
    
    public void Main(string[] args)
    {
      UseThing(args);  // only called in DEBUG builds
      // rest of Main goes here
    }
