    public void InvalidMethod(Sister input)
    {
      Child castedReference = null;
      // Following 'if' is never true
      if (input is Child)
      {
        // Following statement is invalid C#
        castedReference = (Child)input;
      }
      // Do stuff...
    }
