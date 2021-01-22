    [Test]
    public void MyTest()
    {
       string msg;
       bool result = OldTestClass.MyTest(out msg);
       if (!result)
       {
          Console.WriteLine(msg);
       }
       Assert.AreEqual(result, true);
