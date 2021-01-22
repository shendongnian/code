    DateTime start = DateTime.Now;
    NewEventInfo testEvent1 = FakeEvent("test01action", start); //plus other params for testing
    mServiceClient.AddEvent(testEvent1);
    EventInfo[] eventInfos = null; //code to get back events within time window
    Assert.IsNotEmpty(eventInfos);
    Assert.GreaterOrEqual(eventInfos.Length, 1);
    EventInfo resultEvent1 = eventInfos.FirstOrDefault(e => 
	e.Action == "test01action &&
	e.StartTime.Subtract(testEvent1.StartTime).TotalMilliseconds < 1000); //checks dates are within 1 sec
    Assert.IsNotNull(resultEvent1);
