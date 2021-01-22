    public static class ControlFlow
    {
      public static Exception ResumeOnError(Action action)
      {
        try
        {
          action();
          return null;
        }
        catch (Exception caught)
        { 
          return caught;
        }
      }
    }
