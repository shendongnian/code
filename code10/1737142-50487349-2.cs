    public class TplEventListener : EventListener
    {
        static readonly Guid _tplSourceGuid = new Guid("2e5dba47-a3d2-4d16-8ee0-6671ffdcd7b5");
        readonly EventLevel _handledEventsLevel;
        public TplEventListener(EventLevel handledEventsLevel)
        {
            _handledEventsLevel = handledEventsLevel;
        }
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Guid == _tplSourceGuid)
                EnableEvents(eventSource, _handledEventsLevel);
        }
        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (eventData.EventSource.Guid != _tplSourceGuid)
                return;
            switch (eventData.EventId)
            {
                // TODO: Add case for each relevant EventId (such as TASKSCHEDULED_ID and TASKWAITBEGIN_ID)
                // and explore relevant data (such as task Id) in eventData.Payload. Payload is described by 
                // eventData.PayloadNames.
                // For event ids and payload meaning explore TplEtwProvider source code 
                // (https://referencesource.microsoft.com/#mscorlib/system/threading/Tasks/TPLETWProvider.cs,183).
                default:
                    var message = new StringBuilder();
                    message.Append(eventData.EventName);
                    message.Append("(");
                    message.Append(eventData.EventId);
                    message.Append(") { ");
                    if (!string.IsNullOrEmpty(eventData.Message))
                    {
                        message.Append("Message = \"");
                        message.AppendFormat(eventData.Message, eventData.Payload.ToArray());
                        message.Append("\", ");
                    }
                    for (var i = 0; i < eventData.Payload.Count; ++i)
                    {
                        message.Append(eventData.PayloadNames[i]);
                        message.Append(" = ");
                        message.Append(eventData.Payload[i]);
                        message.Append(", ");
                    }
                    message[message.Length - 2] = ' ';
                    message[message.Length - 1] = '}';
                    Console.WriteLine(message);
                    break;
            }
        }
    }
