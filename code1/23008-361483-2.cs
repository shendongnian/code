        // Conditional("Debug") means that calls to DebugBreak will only be
        // compiled when Debug is defined. DebugBreak will still be compiled
        // even in release mode, but the #if eliminates the code within it.
        // DebuggerHidden is so that, when the break happens, the call stack
        // is at the caller rather than inside of DebugBreak.
        [DebuggerHidden]
        [Conditional("DEBUG")] 
        void DebugBreak()
        {
    #if DEBUG
            if(System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
    #endif
        }
