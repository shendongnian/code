     [TestClass]
     public class TestExpressions
     {
      public class MyClass
      {
       public bool MyMethod(string arg)
       {
        throw new NotImplementedException();
       }
      }
    
      private static string UseExpression<T, Ta1>(Expression<Action<T,Ta1>> run)
      {
       return ((MethodCallExpression)run.Body).Method.Name;
      }
    
      [TestMethod]
      public void TestExpressionParser()
      {
       Assert.AreEqual("MyMethod",
       
       UseExpression<MyClass,string>((c,fakeString) => c.MyMethod(fakeString)));
      }
     }
