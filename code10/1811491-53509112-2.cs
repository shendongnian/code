    public void WhenClientConnected_ButThereIsNoResponse_ItShouldCallShowError() 
    {
       var stubHearbeatTimer = new StubTimer();
       var stubTimeoutTimer = new StubTimer();
       // i'm pretty sure it's possibile mock Actions with moq as well
       var wasSendErrorCalled = false;
       var stubErrorAction = (args) => {
          wasSendErrorCalled = true;
       };
       var sut = new connector(stubHearbeatTimer, stubTimeoutTimer, stubErrorAction );
       sut.OnClientConnected( ..dummyClient..);
       stubTimeoutTimer.TickNow();
       Assert.IsTrue(wasSendErrorCalled);
    }
