    public Task <T> factory (String name)
    {
      Task <T> result;
    
      if (name.CompareTo ("A") == 0)
      {
        result = new TaskA ();
      }
      else if (name.CompareTo ("B") == 0)
      {
        result = new TaskB ();
      }
    
      return result;
    }
