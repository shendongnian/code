public class CallMonitorFactory
{
	public virtual CallMonitor CreateMonitor(args...) {  }
}
public DeviceMediator(IDeviceControlForm form, IDataAccess data, CallMonitorFactory factory)
{
	this.form = form;
	this.data = data;
	CallMonitor = factory.CreateMonitor(OnIncomingCall);
}
