    private AutoResetEvent ReceiveEvent = new AutoResetEvent(false);
    private EventArgs args;
    private bool ReceiveCalled = false;
    // event handler with some argument
    private void Receive(object sender, EventArgs args)
    {
      // get some arguments from the system under test
      this.args= args;
      // set the boolean that the message came in
      ReceiveCalled = true;
      // let the main thread proceed
      ReceiveEvent.Set();
    }
    
    [TestMethod]
    public void Test()
    {
      // register handler
      Server.OnReceive += Receive;
      var message = new Foo();
      Client.Send(message);
      // wait one second for the messages to come in
      ReceiveEvent.WaitOne(1000);
      // check if the message has been received
      Assert.IsTrue(
        ReceiveCalled, 
        "AcceptClientReceived has not been called");
      // assert values from the message
      Assert.IsInstanceOfType(args.Message, typeof(Foo))    
    }
