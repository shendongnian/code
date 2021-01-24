    class CustomLayout : Layout
    {
        protected string GetFormattedMessage(LogEventInfo logEvent)
        {
             // Legacy-style
             return "King of the world";
        }
    
        protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
        {
             // New style supports reusable StringBuilder (reduces allocation)
             target.Append(GetFormattedMessage(logEvent));
        }
    }
