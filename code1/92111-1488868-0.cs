    private AutoResetEvent beginAcceptClientReceivedEvent;
    private int someValue;
    private bool beginAcceptClientReceived = false;
    // event handler with some argument
    private void AcceptClientReceived(int arg)
    {
      // get some arguments from the system under test
      someValue = arg;
      // set the boolean that the message came in
      beginAcceptClientReceived = true;
      // let the main thread proceed
      beginAcceptClientReceivedEvent.Set();
    }
    
    [TestMethod]
    public void Test()
    {
      SystemUnderTest.TcpIpCall(AcceptClientReceived);
      // wait one second for the messages to come in
      beginAcceptClientReceivedEvent.WaitOne(1000);
      // check if the message has been received
      Assert.IsTrue(
        beginAcceptClientReceived, 
        "AcceptClientReceived has not been called");
      // assert values from the message
      Assert.AreEqual(expectation, someValue );
    }
