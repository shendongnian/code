    class IdGeneratorAdapter : IdGenerator
    {
      public int GetNext()
      {
        return IdGenerator.GetNext();
      }
    }
