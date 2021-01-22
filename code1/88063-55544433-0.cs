        namespace IntegrationTests
        {
          [Collection("Sequential")]
          public class SequentialTest : IDisposable
          ...
        
          public class TestClass1 : SequentialTest
          {
          ...
          }
    
          public class TestClass2 : SequentialTest
          {
          ...
          }
        }
