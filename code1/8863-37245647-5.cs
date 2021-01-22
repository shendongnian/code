        /// <summary>
        /// Run Async
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="Code">The callback to the code</param>
        /// <param name="Error">The handled and logged exception if one occurs</param>
        /// <returns>The type expected as a competed task</returns>
        public async static Task<T> RunAsync<T>(Func<string,T> Code, Action<Exception> Error)
        {
           var done =  await Task<T>.Run(() =>
            {
                T result = default(T);
                try
                {
                   result = Code("Code Here");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unhandled Exception: " + ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Error(ex);
                }
                return result;
                 
            });
            return done;
        }
        public async void HowToUse()
        {
           //We now inject the type we want the async routine to return!
           var result =  await RunAsync<bool>((code) => {
               //write code here, all exceptions are logged via the wrapped try catch.
               //return what is needed
               return someBoolValue;
           }, 
           error => {
              //exceptions are already handled but are sent back here for further processing
           });
            if (result)
            {
                //we can now process the result because the code above awaited for the completion before
                //moving to this statement
            }
        }
