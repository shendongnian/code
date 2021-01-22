    bool DoOrTimeout<T>(T method, TimeSpan timeout) where T : delegate // FIXME
    {
        bool stopTrying = false;
        DateTime time = DateTime.Now;
        while (!stopTrying)
        {
            try
            {
                method.Invoke();
            }
            catch (Exception ex)
            {
                if (DateTime.Now.Subtract(time).Milliseconds > timeout.TotalMilliseconds)
                {
                    stopTrying = true;
                    throw;
                }
            }
        }
    }
