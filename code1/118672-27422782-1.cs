    public void InvalidMethod<T>(T input)
      where T : Super
    {
      Child castedReference = null;
      if (input is Child)
      {
        // This intuitively ought to be valid C#, but generates a compiletime error
        castedReference = (Child)input;
      }
      // Do stuff...
    }
    
