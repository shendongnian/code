    public class ModifiedTraceFilter : TraceFilter
    {
        private readonly TraceListener _traceListener;
    
        private readonly SourceLevels _originalWebTraceSourceLevel;
    
        private readonly SourceLevels _originalHttpListenerTraceSourceLevel;
    
        private readonly SourceLevels _originalSocketsTraceSourceLevel;
    
        private readonly SourceLevels _originalCacheTraceSourceLevel;
    
        private readonly SourceLevels _modifiedWebTraceTraceSourceLevel;
    
        private readonly SourceLevels _modifiedHttpListenerTraceSourceLevel;
    
        private readonly SourceLevels _modifiedSocketsTraceSourceLevel;
    
        private readonly SourceLevels _modifiedCacheTraceSourceLevel;
    
        private readonly bool _ignoreOriginalSourceLevel;
    
        private readonly TraceFilter _filter = null;
    
        public ModifiedTraceFilter(TraceListener traceListener, SourceLevels originalWebTraceSourceLevel, SourceLevels modifiedWebTraceSourceLevel, SourceLevels originalHttpListenerTraceSourceLevel, SourceLevels modifiedHttpListenerTraceSourceLevel, SourceLevels originalSocketsTraceSourceLevel, SourceLevels modifiedSocketsTraceSourceLevel, SourceLevels originalCacheTraceSourceLevel, SourceLevels modifiedCacheTraceSourceLevel, bool ignoreOriginalSourceLevel)
        {
            _traceListener = traceListener;
            _filter = traceListener.Filter;
            _originalWebTraceSourceLevel = originalWebTraceSourceLevel;
            _modifiedWebTraceTraceSourceLevel = modifiedWebTraceSourceLevel;
            _originalHttpListenerTraceSourceLevel = originalHttpListenerTraceSourceLevel;
            _modifiedHttpListenerTraceSourceLevel = modifiedHttpListenerTraceSourceLevel;
            _originalSocketsTraceSourceLevel = originalSocketsTraceSourceLevel;
            _modifiedSocketsTraceSourceLevel = modifiedSocketsTraceSourceLevel;
            _originalCacheTraceSourceLevel = originalCacheTraceSourceLevel;
            _modifiedCacheTraceSourceLevel = modifiedCacheTraceSourceLevel;
            _ignoreOriginalSourceLevel = ignoreOriginalSourceLevel;
        }
    
        public override bool ShouldTrace(TraceEventCache cache, string source, TraceEventType eventType, int id, string formatOrMessage, object[] args, object data1, object[] data)
        {
            SourceLevels originalTraceSourceLevel = SourceLevels.Off;
            SourceLevels modifiedTraceSourceLevel = SourceLevels.Off;
    
            if (source == "System.Net")
            {
                originalTraceSourceLevel = _originalWebTraceSourceLevel;
                modifiedTraceSourceLevel = _modifiedWebTraceTraceSourceLevel;
            }
            else if (source == "System.Net.HttpListener")
            {
                originalTraceSourceLevel = _originalHttpListenerTraceSourceLevel;
                modifiedTraceSourceLevel = _modifiedHttpListenerTraceSourceLevel;
            }
            else if (source == "System.Net.Sockets")
            {
                originalTraceSourceLevel = _originalSocketsTraceSourceLevel;
                modifiedTraceSourceLevel = _modifiedSocketsTraceSourceLevel;
            }
            else if (source == "System.Net.Cache")
            {
                originalTraceSourceLevel = _originalCacheTraceSourceLevel;
                modifiedTraceSourceLevel = _modifiedCacheTraceSourceLevel;
            }
    
            var level = ConvertToSourceLevel(eventType);
            if (!_ignoreOriginalSourceLevel && (originalTraceSourceLevel & level) == level)
            {
                if (_filter == null)
                {
                    return true;
                }
                else
                {
                    return _filter.ShouldTrace(cache, source, eventType, id, formatOrMessage, args, data1, data);
                }
            }
            else if (_ignoreOriginalSourceLevel && (modifiedTraceSourceLevel & level) == level)
            {
                if (_filter == null)
                {
                    return true;
                }
                else
                {
                    return _filter.ShouldTrace(cache, source, eventType, id, formatOrMessage, args, data1, data);
                }
            }
    
            return false;
        }
    
        private static SourceLevels ConvertToSourceLevel(TraceEventType eventType)
        {
            switch (eventType)
            {
                case TraceEventType.Critical:
                    return SourceLevels.Critical;
                case TraceEventType.Error:
                    return SourceLevels.Error;
                case TraceEventType.Information:
                    return SourceLevels.Information;
                case TraceEventType.Verbose:
                    return SourceLevels.Verbose;
                case TraceEventType.Warning:
                    return SourceLevels.Warning;
                default:
                    return SourceLevels.ActivityTracing;
            }
        }
    }
