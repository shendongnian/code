    public static class ExceptionAssert
    {
        /// <summary>
        /// Use this method if your UT is using <see cref="ExpectedExceptionAttribute"/> and you want to verify additional expectations
        /// </summary>
        /// <typeparam name="T">The expected exception type base</typeparam>
        /// <param name="action">Execute the unit to test</param>
        /// <param name="verifier">Verify the additional expectations</param>
        public static void AssertException<T>(Action action, Action<T> verifier) where T: Exception
        {
            try
            {
                action();
            }
            catch(T e)
            {
                verifier(e);
                throw;
            }
        }
        /// <summary>
        /// Use this method if your UT is not using <see cref="ExpectedExceptionAttribute"/> and you want to verify additional expectations
        /// </summary>
        /// <typeparam name="T">The expected exception type base</typeparam>
        /// <param name="action">Execute the unit to test</param>
        /// <param name="verifier">Verify the additional expectations</param>
        /// <param name="allowDriven">Indicates if the raised exception can be an instance of driven class</param>
        public static void AssertExceptionWithoutExcepctedExceptionAttribute<T>(Action action, Action<T> verifier, bool allowDriven = true) where T : Exception
        {
            try
            {
                action();
                Assert.Fail("No Exception raised");
            }
            catch (T e)
            {
                if (!allowDriven && e.GetType() != typeof(T))
                {
                    Assert.Fail($"The raised exception :: {e.GetType()} is a driven instance of :: {typeof(T)}");
                }
                verifier(e);
            }
        }
    }
