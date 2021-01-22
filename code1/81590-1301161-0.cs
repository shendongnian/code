    [TestInitialize()]
    public void MyTestInitialize()
    {
        form = MockRepository.GenerateMock<IAddAddressForm>();
        // Make the properties work like a normal property
        Expect.Call(form.OKButtonEnabled).PropertyBehavior();
        //I tried this too.  I still get the exception
        //SetupResult.For(form.OKButtonEnabled).PropertyBehavior();
        MockRepository.ReplyAll();
        mediator = new AddAddressMediator(form);
        
    }
