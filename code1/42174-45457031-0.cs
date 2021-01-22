    private class TestClass : IDisposable
    {
       private readonly string id;
    
       public TestClass(string id)
       {
          Console.WriteLine("'{0}' is created.", id);
          this.id = id;
       }
    
       public void Dispose()
       {
          Console.WriteLine("'{0}' is disposed.", id);
       }
    
       public override string ToString()
       {
          return id;
       }
    }
    
    private static TestClass TestUsingClose()
    {
       using (var t1 = new TestClass("t1"))
       {
          using (var t2 = new TestClass("t2"))
          {
             using (var t3 = new TestClass("t3"))
             {
                return new TestClass(String.Format("Created from {0}, {1}, {2}", t1, t2, t3));
             }
          }
       }
    }
    
    [TestMethod]
    public void Test()
    {
       Assert.AreEqual("Created from t1, t2, t3", TestUsingClose().ToString());
    }
