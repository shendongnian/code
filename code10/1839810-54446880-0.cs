C#
private static readonly SemaphoreSlim _mutex = new SemaphoreSlim(1);
public async Task UpdateItem(int mediaItemId)
{
  using (var connection = _dataService.OpenDbConnection())
  {
    await _mutex.WaitAsync();
    try
    {
      using (var transaction = await connection.BeginTransaction())
      {
        var item = await connection.SingleByIdAsync<MediaItem>(mediaItemId);
        item.Index++;
        await connection.UpdateAsync(item);
        transaction.Commit();
      }
    }
    finally
    {
      _mutex.Release();
    }
  }
}
Or, [using AsyncEx for a nicer syntax](http://dotnetapis.com/pkg/Nito.AsyncEx.Coordination/5.0.0-pre-05/netstandard2.0/doc/Nito.AsyncEx.SemaphoreSlimExtensions):
C#
private static readonly SemaphoreSlim _mutex = new SemaphoreSlim(1);
public async Task UpdateItem(int mediaItemId)
{
  using (var connection = _dataService.OpenDbConnection())
  using (_mutex.LockAsync())
  using (var transaction = await connection.BeginTransaction())
  {
    var item = await connection.SingleByIdAsync<MediaItem>(mediaItemId);
    item.Index++;
    await connection.UpdateAsync(item);
    transaction.Commit();
  }
}
