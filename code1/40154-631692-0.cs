    // Definition.
    delegate string TransformDelegate(string input);
    
    // Client code.  This is some lengthy operation.  You can also
    // assign a function here if you want.
    TransformDelegate t = (x) => ...;
    
    // Begin invoking.
    t.BeginInvoke("input", (ar) => 
    {
        // Call end invoke.
        string result = t.EndInvoke(ar);
    
        // Dispose of wait handle, known issue documented here.
        // https://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=94068
        using (IDisposable d = ar.WaitHandle) { }
    
        // Process end result here.  Remember, on another thread now.
    }, null);
