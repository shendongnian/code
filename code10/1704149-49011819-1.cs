    CancelEventArgs e = new CancelEventArgs(false);
    try
    {
        // The event handler is called here
        OnClosing(e);
    }
    catch
    {
        CloseWindowBeforeShow();
        throw;
    }
    
    // The status of the .Cancel on the EventArgs is not checked until here
    if (ShouldCloseWindow(e.Cancel))
    {
        CloseWindowBeforeShow();
    }
    else
    {
        _isClosing = false;
        // 03/14/2006 -- hamidm
        // WOSB 1560557 Dialog does not close with ESC key after it has been cancelled
        //
        // No need to reset DialogResult to null here since source window is null.  That means
        // that ShowDialog has not been called and thus no need to worry about DialogResult.
    }
