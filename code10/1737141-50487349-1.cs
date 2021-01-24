    public class TplEventListener : EventListener
    {
        static readonly Guid _tplSourceGuid = new Guid("2e5dba47-a3d2-4d16-8ee0-6671ffdcd7b5");
        // For other ids such as TASKSCHEDULED_ID see TplEtwProvider source code
        // (https://referencesource.microsoft.com/#mscorlib/system/threading/Tasks/TPLETWProvider.cs,183).
        const int TRACEOPERATIONSTART_ID = 14;
        const int TRACEOPERATIONSTOP_ID = 15;
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Guid == _tplSourceGuid)
                EnableEvents(eventSource, EventLevel.LogAlways);
        }
        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (eventData.EventSource.Guid != _tplSourceGuid)
                return;
            switch (eventData.EventId)
            {
                case TRACEOPERATIONSTART_ID:
                case TRACEOPERATIONSTOP_ID:
                    Console.WriteLine(eventData.EventName + ": Task " + eventData.Payload[0] + " " + eventData.Payload[1]);
                    break;
                // TODO: Add cases for other EventId and explore relevant data (such as task Id) in eventData.Payload. 
                // Payload is described by eventData.PayloadNames.
                default:
                    if (!string.IsNullOrEmpty(eventData.Message))
                        Console.WriteLine(eventData.EventName + ": " + eventData.Message, eventData.Payload.ToArray());
                    break;
            }
 
        }
    }
