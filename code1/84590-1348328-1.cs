[Test]
public void IncomingCallTest()
{
	IEventRaiser callEvent;
	CallMonitor monitor = mocks.Stub<CallMonitor>(args..);
	using(mocks.Record())
	{
		callEvent = monitor.Stub(m => m.IncomingCall += null).IgnoreArguments().GetEventRaiser();
		//rest of expectations...
	}
	
	using(mocks.Playback())
	{
		DeviceMediator mediator = new DeviceMediator(form, data, monitor);
		callEvent.Raise(sender, args);
	}
}
