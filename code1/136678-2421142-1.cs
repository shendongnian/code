[TestMethod]
public void TestGetCurrentFloor()
{
    var elevator = new Elevator(Elevator.Environment.Offline);
    elevator.ElevatorArrivedOnFloor += TestElevatorArrived;
    lock (this)
    {
        elevator.GoToFloor(5);
        if (!Monitor.Wait(this, TIMEOUT)) Assert.Fail("Event did not arrive in time.");
    }
    int floor = elevator.GetCurrentFloor();
    Assert.AreEqual(floor, 5);
}
private void TestElevatorArrived(int floor)
{
    lock (this)
    {
        Monitor.Pulse(this);
    }
}
(The Assert.Fail() call here should be replaced with whatever mechanism your unit-testing tool uses for explicitly failing a test — or you could throw an exception.)
