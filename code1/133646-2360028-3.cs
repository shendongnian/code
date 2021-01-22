    [Test]
    public void Reset_clears_Foo_Bar()
    {
       var foo = MockRepository.GenerateStub<IFoo>();
       foo.Bar = "some string which is not null";
       var underTest = new UnderTest(foo);
       
       underTest.Reset();
       // assert that the class under test updated the Bar property as designed
       Assert.IsNull(foo.Bar);
    }
