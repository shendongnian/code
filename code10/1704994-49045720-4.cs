    public class Delayer
    {
        public async Task Execute(Func<Task> action)
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
