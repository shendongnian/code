    private void ViewOnLoadingFrameFailed(object sender, LoadingFrameFailedEventArgs e)
    {
        if (e.IsMainFrame)
        {
            var error = (NetError) e.ErrorCode;
            Logger.ErrorFormat("main frame loading failed: {0}-{1}", e.ErrorCode, e.ErrorDescription);
        }
        else
        {
            Logger.WarnFormat("frame #{0} loading failed: {1} - {2}", e.FrameId, e.ErrorCode, e.ErrorDescription);
        }
    }
