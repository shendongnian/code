    IService service = MockRepository.GenerateStub<IService>();
    IHandler stubHandler = MockRepository.GenerateStub<IHandler>();
    service.Stub(s => s.ServiceHandler).Return(stubHandler);
    
    //assertions
