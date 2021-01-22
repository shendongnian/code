    public class Bling
    {
        public static void DoBling()
        {
            using (MyScopedBehavior.Begin(() =>
            {
                //Do something.
            }));
        }   
    }
    public sealed class MyScopedBehavior : IDisposable
    {
        private readonly Exception _ex;
        private MyScopedBehavior(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                _ex = ex;
                throw;
            }
        }
        public void Dispose()
        {
            if (_ex != null)
            {
                //I only want to execute the following if we're not unwinding through finally due to an exception:
                //...End of scope behavior    
            }
        }
        public static MyScopedBehavior Begin(Action action)
        {
            return new MyScopedBehavior(action);
        }
    }
