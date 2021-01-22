    public class AdditionFixture : IDisposable
    {
      public int Because() 
      {
        return 2 + 2;
      }
      public void Dispose()
      {
       //test tear down code
      }      
    }
