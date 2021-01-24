    class CustomEventListener : EventListener
    {
        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
        }
    }
    void Main() 
    {
        var src = new CustomEventSource();
        var listener = new CustomEventListener();
        Console.WriteLine(src.IsEnabled(EventLevel.LogAlways, EventKeywords.None)); // false
        listener.EnableEvents(src, EventLevel.Error);
        Console.WriteLine(src.IsEnabled(EventLevel.LogAlways, EventKeywords.None)); // true
        Console.WriteLine(src.IsEnabled(EventLevel.Critical, EventKeywords.None)); // true
        Console.WriteLine(src.IsEnabled(EventLevel.Verbose, EventKeywords.None)); // false
    }
