    public class Delayer
    {
        public async Task Execute(Func<Task> action) // or public async void Execute(Func<Task> action) if you insist on it.
        {
            try
            {
                await Task.Delay(10).ConfigureAwait(false);
                await action.Invoke();
            }
            catch(Exception ex)
            {
                // ...
            }
        }
    }
