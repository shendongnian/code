    [Test]
    public void Updates_Caption_when_Bar_PropertyChanged()
    {
       var foo = MockRepository.GenerateStub<IFoo>();
       foo.Bar = "sometestvalue1";
       var underTest = new UnderTest(foo);
       // change property and raise PropertyChanged event on mock object
       foo.Bar = "sometestvalue2";
       foo.Raise(x=>x.PropertyChanged+=null,
           foo,
           new PropertyChangedEventArgs("Bar"));
       // assert that the class under test reacted as designed
       Assert.AreEqual("sometestvalue2", underTest.Caption);
       // or if the the expected state change is hard to verify, 
       // you might just verify that the property was at least read
       foo.AssertWasCalled(x => { var y = foo.Bar; } );
    }
