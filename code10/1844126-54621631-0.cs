    private CancellationTokenSource cancellationTokenSource; // And remove isCanceled as this is causing some of the issues
private async void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    var progress = new Progress<int>(percent =>
                    {
                        prg.Value = percent;
                    });
    // Make sure any current processing is stopped.
    cancellationTokenSource?.Cancel();
    // Prepare to be able to cancel the next round of processing.
    cancellationTokenSource = new CancellationTokenSource();
    await ExecuteManuallyCancellableTaskAsync(progress, cancellationTokenSource.Token);
}
public async Task ExecuteManuallyCancellableTaskAsync(IProgress<int> progress, CancellationToken cancelToken)
{
    var mprogress = 0;
    prg.Value = 0;
    await Task.Run(async () =>
    {
        // You will need to implement checks against the CancellationToken in your GetFileListAsync method also.
        foreach (var file in await GetFileListAsync(GlobalData.Config.DataPath, cancelToken))
        {
            mprogress += 1;
            progress.Report((mprogress * 100 / TotalItem));
            // Only update the UI if we have not been requested to cancel.
            if (!cancelToken.IsCancellationRequested)
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    // my codes
                }, DispatcherPriority.Background);
            }
        }
    }, cancelToken); // Pass in the token to allow the Task to be cancelled.
}
