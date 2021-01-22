    // a nice neat public interface to centralize all of your 
    // run time requirements
    public interface IRuntimeInfo
    {
        // true if silverlight runtime, false if full-Clr
        bool IsSilverlight { get; }
    }
