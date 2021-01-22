    [Test]
    public void TestMethod() {
        myObject.Event1 += (sender, args) => Event.Call("Event1Label");
        myObject.Event2 += (sender, args) => Event.Call("Event2Label");
        myObject.Event3 += (sender, args) => Event.Call("Event3Label");        
        myObject.SomeEventTrigger();
        EventMock.Verify(m => m.Call("Event1Label"), Times.Exactly(1));
        EventMock.Verify(m => m.Call("Event2Label"), Times.Never());
        EventMock.Verify(m => m.Call("Event3Label"), Times.Between(1,3);
        
    }
