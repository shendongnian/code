    interface IStringGenerator
    {
        string GenerateNext();
    }
    class FixStringGenerator:IStringGenerator
    {
      public FixStringGenerator(int length)
      {
       ...
      }
      public string GenerateNext()
      {
          ///logic
      }
    ...
    }
