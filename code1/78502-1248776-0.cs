    public class RenderingMemoryAppender : MemoryAppender
    {
    
        public IEnumerable<string> GetRenderedEvents()
        {
            foreach(var loggingEvent in GetEvents())
            {
                yield return RenderLoggingEvent(loggingEvent);
            }
        }
    }
