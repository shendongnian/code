    private readonly object changeVarsLockObject = new object();
    private void changeVars()
    {
      lock(changeVarsLockObject)
      {
        a = 4;
        b = 2;
        c = a+b;
      }
    }
