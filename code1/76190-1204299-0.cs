    [TestMethod]
    public void LogonFailure()
    {
        var presenter = new LogOn();
        var view = MockRepository.CreateMock<ILogOn>();
        
        view.Expect(v => v.Username).Return("invalid").Repeat.Any();
        view.Expect(v => v.SubmitFail(null)).Constraints(Is.Same("Username is incorrect"));
        
        presenter.Setup(view);
        
        view.Raise(v => v.Submit += null, null, EventArgs.Empty);
    
        view.VerifyAllExpectations();
    }
