    public actionresult SomeMethod(FormCollection form)
    {
      if (form.AllKeys.Contains("Button1")
      {
        doSomething();
      }
      else // asuming only two sub,it buttons
      {
        doSomethingElse();
      }
    }
