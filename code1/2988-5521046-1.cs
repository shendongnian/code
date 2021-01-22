    public sealed class EventWatcher : IDisposable {
         private readonly object _target;
         private readonly EventInfo _eventInfo;
         private readonly Delegate _listener;
         private bool _eventWasRaised;
         public static EventWatcher Create<T>(T target, string eventName) {
             EventInfo eventInfo = typeof(T).GetEvent(eventName);
             if (eventInfo == null)
                throw new ArgumentException("Event was not found.", eventName);
             return new EventWatcher(target, eventInfo);
         }
         private EventWatcher(object target, EventInfo eventInfo) {
             _target = target;
             _eventInfo = event;
             _listener = CreateEventDelegateForType(_eventInfo.EventHandlerType);
             _eventInfo.AddEventHandler(_target, _listener);
         }
         // SetEventWasRaised()
         // CreateEventDelegateForType
         void IDisposable.Dispose() {
             _eventInfo.RemoveEventHandler(_target, _listener);
             if (!_eventWasRaised)
                throw new InvalidOperationException("event was not raised.");
         }
    }
