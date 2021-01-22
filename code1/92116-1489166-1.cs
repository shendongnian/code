    public void TestFooMessage() {
        Foo message = null;
        var resetEvent = new AutoResetEvent(false);
    
        Server.OnReceive += (s, e) => {
             message = e.Message;
             resetEvent.Set();
        };
    
        var message = new Foo();
        Client.Send(message);
    
        if (resetEvent.WaitOne(1000)) {
             Assert.IsInstanceOfType(e.Message, typeof(Foo));
        } else {
             Assert.Fail("Foo not received!");
        }
    }
