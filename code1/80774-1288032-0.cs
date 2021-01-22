    class Job
    {
      Action<int> m_delegate;
    
      public Job(ref int x)
      {
        m_delegate = delegate(int newValue)
        {
          x = newValue;
        };
      }
    
      public void Execute()
      {
        //set the passed-in varaible to 5, via the anonymous delegate
        m_delegate(5);
      }
    }
