    [TestMethod]
    public void TestGetCurrentFloor()
    {
        // NUnit has something very similar to this, I'm going from memory
        this.TestCounter.reset(); 
    
        var elevator = new Elevator(Elevator.Environment.Offline);
        elevator.ElevatorArrivedOnFloor += (s,e) => { Assert.That(e.floor).Is(5) }
        elevator.GoToFloor(5);
        // It should complete within 5 seconds..
        Thread.Sleep(1000 * 5);
        Assert.That(elevator.GetCurrentFloor()).Is(5);
        Assert.That(this.TestCounter.Count).Is(0);
    }
