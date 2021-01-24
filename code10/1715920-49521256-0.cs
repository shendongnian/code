    public static bool TryExecute(Action action, int retry, int secondBeforeRetry, List<Type> notSupportedExceptions, List<Type> veryBadExceptions, List<Type> retryableExceptions)
        {
            var success = false;
            // keep trying to run the action
            for (int i = 0; i < retry; i++)
            {
                try
                {
                    // run action
                    action.Invoke();
                  
                    // if it reached here it was successful
                    success = true;
                    // break the loop
                    break;
                }
                catch (Exception ex)
                {
                    // if the exception is not retryable
                    if (!retryableExceptions.Contains(ex.GetType()))
                    {
                        // if its a not supported exception
                        if (notSupportedExceptions.Contains(ex.GetType()))
                        {
                            throw new Exception("No supported");
                        }
                        else if (veryBadExceptions.Contains(ex.GetType()))
                        {
                            throw new Exception("Very bad");
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(secondBeforeRetry * 1000);
                    }
                }
            }
            return success;
        }
