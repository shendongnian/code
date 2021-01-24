C#
public Task<bool> ShowMessageBoxAsync(string message)
{
  var tcs = new TaskCompletionSource<bool>();
  Device.BeginInvokeOnMainThread(async () =>
  {
    try
    {
      var result = await DisplayAlert("Error", message, "OK", "Cancel");
      tcs.TrySetResult(result);
    }
    catch (Exception ex)
    {
      tcs.TrySetException(ex);
    }
  });
  return tcs.Task;
}
This should get you unblocked for now. However, a better long-term solution would be to have your background thread logic take some kind of "interact with the UI" interface like this:
C#
public interface IAskUser
{
  Task<bool> AskUserAsync(string message);
}
with a Xamarin-Forms-specific implementation similar to above.
That way, your background thread logic isn't tied to a specific UI, and can be more easily unit tested and reused.
