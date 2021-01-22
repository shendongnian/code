    public actionresult SomeMethod(FormCollection form)
    {
      if (form.AllKeys.Contains("Button1")
      {
        doSomething();
      }
      else // assuming only two submit buttons
      {
        doSomethingElse();
      }
    }
