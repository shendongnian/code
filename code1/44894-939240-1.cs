    [Test]
    public void MyComplexTest
    {
       var array = new Foo[] { new Foo(123), new Foo(456), new Foo(789) };
       Assert.Sorted(array, new StructuralEqualityComparer<Foo>
       {
          { x => x.Value }
       });
    }
