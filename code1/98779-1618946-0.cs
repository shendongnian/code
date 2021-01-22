    public inteface IExecute {
      void Execute(string input)
    }
    _connectionService
        .Stub(c => c.RemoteCall(null)).IgnoreArguments()
        .Do(new Func<Action<IExecute>,bool>( func => {
           var stub = MockRepository.GenerateStub<IExecute>();
           func(stub);
           stub.AssertWasCalled(x => x.Execute("test"));
           return true;
         }));;
