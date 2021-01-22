    public static string GetNameOfCurrentMethod()
    {
        // Skip 1 frame (this method call)
        var trace = new System.Diagnostics.StackTrace( 1 );
        var frame = trace.GetFrame( 0 );
        return frame.GetMethod().Name;
    }
