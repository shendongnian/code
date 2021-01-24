    void ProcessFoos(IEnumerable<ISomething<IFoo>> somethings)
    {
      foreach (var something in somethings)
      {
        var outputs = something.Outputs();
        var barOutputs = outputs.OfType<IBar>();
        var bazOutputs = outputs.OfType<IBaz>();
        // do something with outputs
      }
    }
