    public class Star : IDisposable
    {
        ...
        public void Dispose()
        {
            if (aTimer != null)
            {
                aTimer.Dispose();
                aTimer = null;
            }
        }
        ...
    }
