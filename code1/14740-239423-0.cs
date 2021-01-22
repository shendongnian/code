    [Test]
    public void TestFoo() {
      ActualTest<Foo>();
    }
    [Test]
    public void TestBar() {
      ActualTest<Bar>();
    }
    static void ActualTest<T>() where T : SomeBaseClass, new() {
      T obj = new T();
      Assert.blah something involving obj
    }
