    protected delegate void ExceptionThrower();
    /// <summary>
    /// Asserts that calling a method results in an exception of the stated type with the stated message.
    /// </summary>
    /// <param name="exceptionThrowingFunc">Delegate that calls the method to be tested.</param>
    /// <param name="expectedExceptionType">The expected type of the exception, e.g. typeof(FormatException).</param>
    /// <param name="expectedExceptionMessage">The expected exception message (or fragment of the whole message)</param>
    protected void AssertThrowsException(ExceptionThrower exceptionThrowingFunc, Type expectedExceptionType, string expectedExceptionMessage)
    {
        try
        {
            exceptionThrowingFunc();
            Assert.Fail("Call did not raise any exception, but one was expected.");
        }
        catch (NUnit.Framework.AssertionException)
        {
            // Ignore and rethrow NUnit exception
            throw;
        }
        catch (Exception ex)
        {
            Assert.IsInstanceOfType(expectedExceptionType, ex, "Exception raised was not the expected type.");
            Assert.IsTrue(ex.Message.Contains(expectedExceptionMessage), "Exception raised did not contain expected message. Expected=\"" + expectedExceptionMessage + "\", got \"" + ex.Message + "\"");
        }
    }
    /// <summary>
    /// Asserts that calling a method does not throw an exception.
    /// </summary>
    /// <remarks>
    /// This is typically only used in conjunction with <see cref="AssertThrowsException"/>. (e.g. once you have tested that an ExceptionThrower
    /// method throws an exception then your test may fix the cause of the exception and then call this to make sure it is now fixed).
    /// </remarks>
    /// <param name="exceptionThrowingFunc">Delegate that calls the method to be tested.</param>
    protected void AssertDoesNotThrowException(ExceptionThrower exceptionThrowingFunc)
    {
        try
        {
            exceptionThrowingFunc();
        }
        catch (NUnit.Framework.AssertionException)
        {
            // Ignore and rethrow any NUnit exception
            throw;
        }
        catch (Exception ex)
        {
            Assert.Fail("Call raised an unexpected exception: " + ex.Message);
        }
    }
