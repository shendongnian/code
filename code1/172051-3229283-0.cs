    [Test]
    public void MyTest()
    {
        // arrange
        IDoStuff doer = MockRepository.GenerateStub<IDoStuff>();
        MyClass myClass = new Myclass(doer);
        Guid id = Guid.NewGuid();
    
        // act
        myClass.Go(new SomeClass(){id = id});
    
        // assert
        doer.AssertWasCalled(x => x.DoStuff(
            Arg<Someclass>.Matches(y => y.id == id)));
    }
