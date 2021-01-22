    [TestMethod]
    public void TestMethod8()
    {
        using (new MyClass() as IDisposable)
        {
        }
    }
    public class MyClass { }
