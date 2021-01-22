        /// <summary>
        /// The maximum amount of attempts to use before giving up on an update, delete or create
        /// </summary>
        private const int MAX_ATTEMPTS = 2;
        /// <summary>
        /// Attempts to execute the specified delegate with the specified arguments.
        /// </summary>
        /// <param name="operation">The operation to attempt.</param>
        /// <param name="arguments">The arguments to provide to the operation.</param>
        /// <returns>The result of the operation if there are any.</returns>
        public static object attemptOperation(Delegate operation, params object[] arguments)
        {
            //attempt the operation using the default max attempts
            return attemptOperation(MAX_ATTEMPTS, operation, arguments);
        }
        /// <summary>
        /// Use for creating a random delay between retry attempts.
        /// </summary>
        private static Random random = new Random();
        /// <summary>
        /// Attempts to execute the specified delegate with the specified arguments.
        /// </summary>
        /// <param name="operation">The operation to attempt.</param>
        /// <param name="arguments">The arguments to provide to the operation.</param>
        /// <param name="maxAttempts">The number of times to attempt the operation before giving up.</param>
        /// <returns>The result of the operation if there are any.</returns>
        public static object attemptOperation(int maxAttempts, Delegate operation, params object [] arguments)
        {
            //set our initial attempt count
            int attemptCount = 1;
            //set the default result
            object result = null;
            //we've not succeeded yet
            bool success = false;
            //keep trying until we get a result
            while (success == false)
            {
                try
                {
                    //attempt the operation and get the result
                    result = operation.DynamicInvoke(arguments);
                    //we succeeded if there wasn't an exception
                    success = true;
                }
                catch
                {
                    //if we've got to the max attempts and still have an error, give up an rethrow it
                    if (attemptCount++ == maxAttempts)
                    {
                        //propogate the exception
                        throw;
                    }
                    else
                    {
                        //create a random delay in milliseconds
                        int randomDelayMilliseconds = random.Next(1000, 5000);
                        //sleep for the specified amount of milliseconds
                        System.Threading.Thread.Sleep(randomDelayMilliseconds);
                    }
                }
            }
            //return the result
            return result;
        }
