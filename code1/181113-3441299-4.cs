    // most of us will recognize this as a thinly veiled 
    // log4net subset, extend or reduce to address our
    // framework's requirements
    public interface ILog
    {
        bool IsDebugEnabled { get; }
        void Debug(object message);
        void Debug(object message, Exception exception);
        void DebugFormat(string format, params object[] args);
    }
