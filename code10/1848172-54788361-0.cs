C#
async void asyncMethod()
{
  ...
  try
  {
    var data = myUiComponent.Text;
    _cts.CancelAfter(25000);
    int count = await awaitMethod(data, _cts.Token, progress);
  }
  ...
}
async Task<int> awaitMethod(string data, CancellationToken ct, IProgress<double> progress)
{
  var task = Task.Run(() =>
  {
    ct.ThrowIfCancellationRequested();
    sqlParser(data);
    progress.Report(1);
    return 0;
  });
  return await task;
}
