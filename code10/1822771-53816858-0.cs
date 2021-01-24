    >    public static Policy<HttpWebResponse> Get429WebResponseWaitRetryPolicy()
            {
                //Retries policy
                return Policy.Handle<WebException>().OrResult<HttpWebResponse>(r => r == null)
                    .WaitAndRetry(15, // We can also do this with WaitAndRetryForever... but chose WaitAndRetry this time.
                    attempt => TimeSpan.FromSeconds(0.1 * Math.Pow(2, attempt)), // Back off!  2, 4, 8, 16 etc times 1/4-second
                    (exception, calculatedWaitDuration) =>  // Capture some info for logging! if needed
                    {
                        // This is your new exception handler! 
                        Debug.WriteLine("Retry count: " + retries++);
                        Debug.WriteLine("Wait Duration: " + calculatedWaitDuration);
                    });
            }
