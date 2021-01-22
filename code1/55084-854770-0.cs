    private Two _two;
    public Two Two
    {
         get 
         {
           if (null == _two)
             return new Two();
           else
             return _two;
          }
    }
