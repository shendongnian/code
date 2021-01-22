    public class Delayer : IDisposable
    {
        // same code as above, plus...
    
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
