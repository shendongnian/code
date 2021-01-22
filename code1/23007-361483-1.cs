        // Conditional("Debug") means that calls to DebugBreak will only be
        // compiled when Debug is defined. DebugBreak will still be compiled
        // even in release mode, but the #if eliminates the code within it.
        [Conditional("DEBUG")] 
        void DebugBreak()
        {
    #if DEBUG
            if(System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
    #endif
        }
