    try
    {
      var result = DoSomethingOhMyWhatIsTheReturnType();
    }
    catch(LogicException e)
    {
      if(e.InnerException is SqlException)
      {
        // handle sql exceptions
      }else if(e.InnerException is InvalidCastException)
      {
        // handle cast exceptions
      }
      // blah blah blah
    }
