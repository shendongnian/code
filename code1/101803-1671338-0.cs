    public IFooLikeObject CreateBasicIFooLikeObjectStub(MockRepository) {
      IFooLikeObject stub = MockRepository.GenerateStub<IFooLikeObject>();
    
      // These values are required to be non-null
      stub.Stub(s => s.FooLikeObject1).Return("AValidString");
      stub.Stub(s => s.FooLikeObject2).Return("AValidString2");
      stub.Stub(s => s.FooLikeObject5).Return("1");
      stub.Stub(s => s.FooLikeObject6).Return("1");
    }
    [Test]
    void Constructor_FooLikeObject1IsNull_Exception() {
      IFooLikeObject fooLikeObjectStub = CreateBasicIFooLikeObjectStub();
    
      // This line no longer causes an exception
      stub.Stub(s => s.FooLikeObject1).Return(null).Repeat.Any(); // The Repeat.Any() is key. Otherwise the value wont be overridden.
    
      Assert.Throws<ArgumentException>(delegate { new Foo(fooLikeObjectStub); });
    }
