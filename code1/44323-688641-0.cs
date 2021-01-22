    public void MyMethod(params object[] args)
    {
      foreach (object o in args)
      {
        Type t=o.GetType();
        // do something with o depending on the type
        if (t==typeof(int))
        {
          int i=(int)o; 
          // ...
        }
        else if (t==typeof(string)) // etc.
        {
        }
      }
    }
