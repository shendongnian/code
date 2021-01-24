C#
// Original
public async Task<int> LoadAndComputeAsync()
{ 
  var data = await LoadAsync();
  return await ComputeAsync(data);
}
// Using ContinueWith
public Task<int> LoadAndComputeTheHardWayAsync()
{
  var scheduler = SynchronizationContext.Current != null ?
      TaskScheduler.FromCurrentSynchronizationContext() : TaskScheduler.Current;
  LoadAsync().ContinueWith(t =>
      {
        var data = t.GetAwaiter().GetResult();
        return ComputeAsync(data);
      },
      CancellationToken.None,
      TaskContinuationOptions.DenyChildAttach | TaskContinuationOptions.ExecuteSynchronously,
      scheduler).Unwrap();
}
  [1]: https://blog.stephencleary.com/2013/10/continuewith-is-dangerous-too.html
