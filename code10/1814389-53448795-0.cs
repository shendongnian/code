    void foo(int x)
    {
      TerminateIfNegative(x);
      do something more...
         .
         .
         .
         
      EndOfFoo:
    }
    private void TerminateIfNegative(int a)
    {
        if (a<=0)
        {
             goto EndOfFoo;
        }
    }
