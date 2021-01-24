    if ((await o.GetAsync(identifier)) is CallFail callFail)
    {
      Console.WriteLine(callFail.Details);
    }
    // or
    if ((await o.GetAsync(identifier)) is CallSuccessful)
    {
    }
