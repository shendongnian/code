    public void MakeStep()
    {
      try
      {
        InnerMakeStep(); // may throw TAE or some other exception
      }catch(Exception e)
      {
        // log here k 
        throw; // in case it isn't a TAE
      }
    }
