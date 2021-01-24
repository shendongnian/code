    SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
    private void ShowWindowNonBlocking()
    {
        bool acquiredLock = false;
        try
        {
            acquiredLock = semaphore.Wait(0);
            if (acquiredLock)
            {
                // This thread now has exclusive access to the isWindowShown variable
                var result = MessageBox.Show(
                    "Retry the connection?",
                    "Connection Failed",
                    MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Retry)
                {
                    // Retry the connection
                }
            }
            else
            {
                // Another thread is showing the window
            }
        }
        finally
        {
            if (acquiredLock)
            {
                semaphore.Release();
            }
        }
    }
