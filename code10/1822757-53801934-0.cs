    private void OnSuspending(object sender, SuspendingEventArgs e)
    {
        var deferral = e.SuspendingOperation.GetDeferral();
        log.Trace("OnSuspending called");
        deferral.Complete();
    }
    private void OnResuming(object sender, object e)
    {
        log.Trace("OnResuming called");
    }
