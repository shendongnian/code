    public class CallNotification : ITTAPIEventNotification
	{
		public void Event(TAPI_EVENT TapiEvent, object pEvent)
		{
			if(pEvent == null)
				throw new ArgumentNullException(nameof(pEvent));
			switch (TapiEvent)
			{
				case TAPI_EVENT.TE_CALLNOTIFICATION:
					// This event will be raised every time a new call is created on an monitored line-
					// You can use CALLINFO_LONG.CIL_ORIGIN to see weather it's an inbound call, or an
					// outbound call.
					break;
				case TAPI_EVENT.TE_CALLSTATE:
					// This event will be raised every time the state of a call on one of your monitored
					// Lines changes.
					// If you'd want to read information about a call, you can do it here:
					ITCallStateEvent callStateEvent = (ITCallStateEvent)pEvent;
					ITCallInfo call = callStateEvent.Call;
					string calledidname = call.get_CallInfoString(CALLINFO_STRING.CIS_CALLEDIDNAME);
					Console.WriteLine("Called ID Name " + calledidname);
					string callednumber = call.get_CallInfoString(CALLINFO_STRING.CIS_CALLEDIDNUMBER);
					Console.WriteLine("Called Number " + callednumber);
					string calleridname = call.get_CallInfoString(CALLINFO_STRING.CIS_CALLERIDNAME);
					Console.WriteLine("Caller ID Name " + calleridname);
					string callernumber = call.get_CallInfoString(CALLINFO_STRING.CIS_CALLERIDNUMBER);
					Console.WriteLine("Caller Number " + callernumber);
					break;
			}
			// Since you're working with COM objects, you should release any used references.
			Marshal.ReleaseComObject(pEvent); 
		}
	}
