    public class RetryOnError
    {
        static void Example()
        {
          string endOfLineChar = Environment.NewLine;
          RetryOnError.RetryUntil<string>(delegate()
          {
              //attempt some potentially error throwing operations here
    
              //you can access local variables declared outside the the Retry block:
              return "some data after successful processing" + endOfLineChar;
          },
          new RetryOnError.OnException(delegate(ref Exception ex, ref bool rethrow)
          {
              //respond to the error and
              //do some analysis to determine if a retry should occur
              //perhaps prompting the user to correct a problem with a retry dialog
              bool shouldRetry = false;
    
              //maybe log error
              log4net.Error(ex);
    
              //maybe you want to wrap the Exception for some reason
              ex = new Exception("An unrecoverable failure occurred.", ex);
              rethrow = true;//maybe reset stack trace
    
              return shouldRetry;//stop retrying, normally done conditionally instead
          }));
        }
    
      /// <summary>
      /// A delegate that returns type T
      /// </summary>
      /// <typeparam name="T">The type to be returned.</typeparam>
      /// <returns></returns>
      public delegate T Func<T>();
    
      /// <summary>
      /// An exception handler that returns false if Exception should be propogated
      /// or true if it should be ignored.
      /// </summary>
      /// <returns>A indicater of whether an exception should be ignored(true) or propogated(false).</returns>
      public delegate bool OnException(ref Exception ex, ref bool rethrow);
    
      /// <summary>
      /// Repeatedly executes retryThis until it executes successfully with
      /// an exception, maxTries is reached, or onException returns false.
      /// If retryThis is succesful, then its return value is returned by RetryUntil.
      /// </summary>
      /// <typeparam name="T">The type returned by retryThis, and subsequently returned by RetryUntil</typeparam>
      /// <param name="retryThis">The delegate to be called until success or until break condition.</param>
      /// <param name="onException">Exception handler that can be implemented to perform logging,
      /// notify user, and indicates whether retrying should continue.  Return of true indicates
      /// ignore exception and continue execution, and false indicates break retrying and the
      /// exception will be propogated.</param>
      /// <param name="maxTries">Once retryThis has been called unsuccessfully <c>maxTries</c> times, then the exception is propagated.
      /// If maxTries is zero, then it will retry forever until success.
      /// </param>
      /// <returns>The value returned by retryThis on successful execution.</returns>
      public static T RetryUntil<T>(Func<T> retryThis, OnException onException, int maxTries)
      {
        //loop will run until either no exception occurs, or an exception is propogated(see catch block)
        int i = 0;
        while(true)
        {
          try
          {
            return retryThis();
          }
          catch ( Exception ex )
          {
            bool rethrow =false;//by default don't rethrow, just throw; to preserve stack trace
            if ( (i + 1) == maxTries )
            {//if on last try, propogate exception
              throw;
            }
            else if (onException(ref ex, ref rethrow))
            {
              if (maxTries != 0)
              {//if not infinite retries
                ++i;
              }
              continue;//ignore exception and continue
            }
            else
            {
              if (rethrow)
              {
                throw ex;//propogate exception
              }
              else
              {//else preserve stack trace
                throw;
              }
            }
          }
        }
      }
    
      /// <summary>
      /// Repeatedly executes retryThis until it executes successfully with
      /// an exception, or onException returns false.
      /// If retryThis is succesful, then its return value is returned by RetryUntil.
      /// This function will run infinitly until success or onException returns false.
      /// </summary>
      /// <typeparam name="T">The type returned by retryThis, and subsequently returned by RetryUntil</typeparam>
      /// <param name="retryThis">The delegate to be called until success or until break condition.</param>
      /// <param name="onException">Exception handler that can be implemented to perform logging,
      /// notify user, and indicates whether retrying should continue.  Return of true indicates
      /// ignore exception and continue execution, and false indicates break retrying and the
      /// exception will be propogated.</param>
      /// <returns></returns>
      public static T RetryUntil<T>(Func<T> retryThis, OnException onException)
      {
        return RetryUntil<T>(retryThis, onException, 0);
      }
    }
