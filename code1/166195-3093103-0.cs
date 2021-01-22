    [Test]
    public void TryToExecute_SubjectNotYetBeingProcessed_ProcessesSubject()
    {
        ManualResetEvent methodCalled = new ManualResetEvent(false);
        var subject = new Subject();
        var rule = new Mock<IBusinessRule>();
        rule.Setup(x => x.RunChildren(subject)).Do(X=>methodCalled.Set()); //RunChildren will be called in a seperate Thread
        InBuffer.TryToExecute(subject, rule.Object);
        Assert.IsTrue(methodCalled.WaitOne(1000), "RunChildren was not called within 1000ms");
    }
