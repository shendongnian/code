    MockRepository mocks = new MockRepository();
    IService service = mocks.CreateStub<IService>();
    IHandler handler = mocks.CreateStub<IHandler>();
    
    using (mocks.Record())
    {
    	SetupResult.For(service.ServiceHandler).Return(handler);
    	//setup expectations using Expect.Call
    }
    
    using (mocks.Playback())
    {
    	//assertions
    }
