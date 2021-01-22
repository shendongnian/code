    private IFoo SetUpFoo()
    {
      IFoo foo = MockRepository.GenerateStub<IFoo>();
      foo.Stub(f => f.DoSomething(0)).IgnoreArguments().Return(0).WhenCalled(mi => mi.ReturnValue = mi.Arguments[0]);
    }
