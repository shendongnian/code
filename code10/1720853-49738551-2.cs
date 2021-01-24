    private async void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
    {
        if (reason == BackgroundTaskCancellationReason.SystemPolicy)
        {
            // WinForm called Application.Exit()
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
        }
        if (this.appServiceDeferral != null)
        {
            // Complete the service deferral.
            this.appServiceDeferral.Complete();
        }
    }
