    // Main Part
    public partial class Class1
    {
        private partial void LogSomethingDebugOnly();
        public void SomeMethod()
        {
            LogSomethingDebugOnly();
            // do the real work
        }
    }
    // Debug Part - probably in a different file
    public partial class Class1
    {
        #if DEBUG
        private partial void LogSomethingDebugOnly()
        {
            // Do the logging or diagnostic work
        }
        #endif
    }
